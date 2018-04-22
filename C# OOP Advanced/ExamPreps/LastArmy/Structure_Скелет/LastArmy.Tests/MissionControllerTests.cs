using NUnit.Framework;
using System.Linq;

public class MissionControllerTests
{
    [Test]
    public void ConstructorTest()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        Assert.That(missionController.SuccessMissionCounter, Is.EqualTo(0));
        Assert.That(missionController.FailedMissionCounter, Is.EqualTo(0));
        Assert.That(missionController.Missions.Count, Is.EqualTo(0));
    }

    [Test]
    public void PerformMissionAddsMissionToQueue()
    {
        IMission firstTestMission = new Medium(180);

        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);
        missionController.PerformMission(firstTestMission);

        Assert.That(missionController.Missions.Count, Is.EqualTo(1));
    }

    [Test]
    public void PerformMissionOnlyAddsUpToThreeMissions()
    {
        IMission firstTestMission = new Medium(180);

        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        for (int i = 0; i < 4; i++)
        {
            missionController.PerformMission(firstTestMission);
        }

        Assert.That(missionController.Missions.Count, Is.EqualTo(3));
    }

    [Test]
    public void PerformMissionDeletesFirstAddedMission()
    {
        IMission firstTestMission = new Medium(180);
        IMission secondTestMission = new Hard(100);

        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        missionController.PerformMission(secondTestMission);
        for (int i = 0; i < 3; i++)
        {
            missionController.PerformMission(firstTestMission);
        }

        var wantedType = missionController.Missions.FirstOrDefault(m => m.GetType().Name == secondTestMission.GetType().Name);

        Assert.That(wantedType, Is.EqualTo(null));
    }

    [Test]
    public void PerformMissionPutsMissionOnHold()
    {
        IMission firstTestMission = new Medium(180);

        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        string result = missionController.PerformMission(firstTestMission).Trim();

        string expectedResult = string.Format(OutputMessages.MissionOnHold, firstTestMission.Name.Trim());

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void MissionControllerDisplaysFailMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(1);
        string result = "";
        for (int counter = 0; counter < 4; counter++)
        {
            result = missionController.PerformMission(mission);
        }

        Assert.IsTrue(result.StartsWith("Mission declined - Suppression of civil rebellion"));
    }

    [Test]
    public void MissionControllerDisplaysSuccessMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(0);
        string result = missionController.PerformMission(mission);

        Assert.IsTrue(result.StartsWith("Mission completed - Suppression of civil rebellion"));
    }
}

