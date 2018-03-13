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
        protected set { name = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        internal set { totalTime = value; }
    }

    public Car Car
    {
        get { return car; }
        protected set { car = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        protected set { fuelConsumptionPerKm = value; }
    }

    public virtual double Speed => (this.Car.Horsepower + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void IncreasTotalTime(int trackLenght)
    {
        this.TotalTime += 60 / (trackLenght / this.Speed);
    }
}
