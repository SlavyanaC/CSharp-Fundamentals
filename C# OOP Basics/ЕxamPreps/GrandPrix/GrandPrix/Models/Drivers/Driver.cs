public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
    }

    public Car Car
    {
        get { return car; }
        private set { car = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        protected set { fuelConsumptionPerKm = value; }
    }

    public virtual double Speed => this.CalculateSpeed();

    public double CalculateSpeed()
    {
        var speed = (this.Car.Horsepower + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        return speed;
    }

    public void IncreasTotalTime(int trackLenght)
    {
        this.TotalTime += 60 / (trackLenght / this.Speed);
    }

    public void ReduceFuelAmount(int trackLenght)
    {
        this.Car.FuelAmount -= trackLenght * this.FuelConsumptionPerKm;
    }
}
