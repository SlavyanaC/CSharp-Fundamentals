using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
        : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime { get; private set; }

    private int ParticipantTimePerformance => this.CalculateTimePerformance();

    public int CalculateTimePerformance()
    {
        Car participant = this.Cars.First().Value;
        return this.Length * ((participant.Horsepower / 100) * participant.Acceleration);
    }

    public override int FirstPrize => this.PrizePool;

    public override int SecondPrize => this.PrizePool * 50 / 100;

    public override int ThirdPrize => this.PrizePool * 30 / 100;

    public override string ToString()
    {
        Car participant = this.Cars.First().Value;
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{this.Route} - {this.Length}");
        builder.AppendLine($"{participant.Brand} {participant.Model} - {this.ParticipantTimePerformance} s.");
        if (this.ParticipantTimePerformance <= this.GoldTime)
        {
            builder.AppendLine($"Gold Time, ${this.FirstPrize}.");
        }
        else if (this.ParticipantTimePerformance <= this.GoldTime + 15)
        {
            builder.AppendLine($"Silver Time, ${this.SecondPrize}.");
        }
        else if (this.ParticipantTimePerformance > this.GoldTime + 15)
        {
            builder.AppendLine($"Bronze Time, ${this.ThirdPrize}.");
        }

        return builder.ToString();
    }
}
