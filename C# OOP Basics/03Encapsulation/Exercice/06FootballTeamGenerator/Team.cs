using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("A name should not be empty.");
            }
            name = value;
        }
    }

    public List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }

    public int Rating => this.CalculateRating();

    public int CalculateRating()
    {
        int result = 0;
        if (this.players.Any())
        {
            result = (int)this.players.Average(p => p.Average);
        }

        return result;
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string player)
    {
        if (!players.Any(p => p.Name == player))
        {
            throw new ArgumentException($"Player {player} is not in {this.Name} team.");
        }

        Player playerToRemove = players.FirstOrDefault(p => p.Name == player);
        this.players.Remove(playerToRemove); 
    }

    public override string ToString()
    {
        return $"{this.name} - {this.Rating}";
    }
}
