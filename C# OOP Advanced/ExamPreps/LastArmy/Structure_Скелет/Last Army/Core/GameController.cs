using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private const string CommandPrefix = "Parse";
    private const string CommandSuffix = "Command";

    private const string RegenerateCommand = "Regenerate";
    private const string ResultOutput = "Results:";
    private const string SoldiersOutpt = "Soldiers:";

    private IWriter writer;
    private IArmy army;
    private IWareHouse wareHouse;
    private IMissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;

    public GameController(IWriter writer)
    {
        this.writer = writer;
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
    }

    public void ProcessCommand(string input)
    {
        List<string> args = input.Split().ToList();
        string command = args[0];
        args = args.Skip(1).ToList();

        string commandFullName = CommandPrefix + command + CommandSuffix;

        try
        {
            MethodInfo method = this.GetType()
                 .GetMethod(commandFullName, BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(this, new object[] { args });
        }
        catch (TargetInvocationException tie)
        {
            throw tie.InnerException;
        }
    }

    private void ParseWareHouseCommand(IList<string> args)
    {
        string ammunitionType = args[0];
        int quiantity = int.Parse(args[1]);
        this.wareHouse.AddAmmunition(ammunitionType, quiantity);
    }

    private void ParseSoldierCommand(IList<string> args)
    {
        if (args[0] == RegenerateCommand)
        {
            string teamToRegenerate = args[1];
            this.army.RegenerateTeam(teamToRegenerate);
        }
        else
        {
            this.AddSoldierToArmy(args);
        }
    }

    private void AddSoldierToArmy(IList<string> args)
    {
        string type = args[0];
        string name = args[1];
        int age = int.Parse(args[2]);
        double experience = double.Parse(args[3]);
        double endurance = double.Parse(args[4]);

        ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
        }

        this.army.AddSoldier(soldier);
    }

    private void ParseMissionCommand(IList<string> args)
    {
        string difficultyLevel = args[0];
        double scoreToComplete = double.Parse(args[1]);

        IMission mission = this.missionFactory.CreateMission(difficultyLevel, scoreToComplete);

        this.writer.StoreMessage(this.missionController.PerformMission(mission));
    }


    public void GetSummary()
    {
        this.missionController.FailMissionsOnHold();

        this.writer.StoreMessage(ResultOutput);
        this.writer.StoreMessage(string.Format(OutputMessages.MissionsSummurySuccessful, this.missionController.SuccessMissionCounter));
        this.writer.StoreMessage(string.Format(OutputMessages.MissionsSummuryFailed,this.missionController.FailedMissionCounter));
        this.writer.StoreMessage(SoldiersOutpt);

        List<ISoldier> orderedSoldiers = this.army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();
        foreach (ISoldier soldier in orderedSoldiers)
        {
            this.writer.StoreMessage(soldier.ToString());
        }
    }
}
