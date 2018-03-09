using System.Collections.Generic;

public class Garage
{
    public Garage()
    {
        this.ParkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars { get; protected set; }

    public void ParkCar(int carId, Car car)
    {
        this.ParkedCars[carId] = car;
    }

    public void UnparkCar(int carId)
    {
        this.ParkedCars.Remove(carId);
    }
}
