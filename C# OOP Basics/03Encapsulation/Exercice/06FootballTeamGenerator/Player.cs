using System;

class Player
{
    private const int MinStat = 0;
    private const int MaxStat = 100;

    private string name;
    private int enducance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    private int Endurance
    {
        get { return enducance; }
        set
        {
            if (value < MinStat || value > MaxStat)
            {
                throw new ArgumentException($"Endurance should be between {MinStat} and {MaxStat}.");
            }
            enducance = value;
        }
    }

    private int Sprint
    {
        get { return sprint; }
        set
        {
            if (value < MinStat || value > MaxStat)
            {
                throw new ArgumentException($"Sprint should be between {MinStat} and {MaxStat}.");
            }
            sprint = value;
        }
    }

    private int Dribble
    {
        get { return dribble; }
        set
        {
            if (value < MinStat || value > MaxStat)
            {
                throw new ArgumentException($"Dribble should be between {MinStat} and {MaxStat}.");
            }
            dribble = value;
        }
    }

    private int Passing
    {
        get { return passing; }
        set
        {
            if (value < MinStat || value > MaxStat)
            {
                throw new ArgumentException($"Passing should be between {MinStat} and {MaxStat}.");
            }
            passing = value;
        }
    }

    private int Shooting
    {
        get { return shooting; }
        set
        {
            if (value < MinStat || value > MaxStat)
            {
                throw new ArgumentException($"Shooting should be between {MinStat} and {MaxStat}.");
            }
            shooting = value;
        }
    }

    public int Average => this.CalculateAverageStats();

    private int CalculateAverageStats()
    {
        var average = (int)Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / (double)5);
        return average;
    }
}
