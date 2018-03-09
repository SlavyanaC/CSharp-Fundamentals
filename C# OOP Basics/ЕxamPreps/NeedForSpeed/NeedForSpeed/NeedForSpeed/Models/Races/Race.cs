using System.Collections.Generic;

public abstract class Race : IPrize
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> cars;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Cars = new Dictionary<int, Car>();
    }

    public int Length
    {
        get { return length; }
        protected set { length = value; }
    }

    public string Route
    {
        get { return route; }
        protected set { route = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        protected set { prizePool = value; }
    }

    public Dictionary<int, Car> Cars
    {
        get { return cars; }
        set { cars = value; }
    }

    public int FirstPrize => this.PrizePool * 50 / 100;

    public int SecondPrize => this.PrizePool * 30 / 100;

    public int ThirdPrize => this.PrizePool * 20 / 100;

    public void AddCar(int carId, Car car)
    {
        this.Cars[carId] = car;
    }

}
