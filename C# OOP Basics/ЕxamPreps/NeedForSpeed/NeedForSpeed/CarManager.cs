using System;
using System.Collections.Generic;

public class CarManager
{
    private Dictionary<int, Car> cars = new Dictionary<int, Car>();
    private Dictionary<int, Race> races = new Dictionary<int, Race>();
    private Garage garage = new Garage();

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        var car = CarFactory.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        this.cars[id] = car;
    }

    public string Check(int id)
    {
        var wantedCar = cars[id];
        return wantedCar.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        var race = RaceFactory.CreateRace(type, length, route, prizePool);
        this.races[id] = race;
    }

    public void Participate(int carId, int raceId)
    {
        if (garage.ParkedCars.ContainsKey(carId))
        {
            return;
        }
        var car = cars[carId];
        var race = races[raceId];
        race.AddCar(carId, car);
    }

    public string Start(int id)
    {
        if (this.races[id].Cars.Count > 0)
        {
            var race = races[id];
            this.races.Remove(id);
            return race.ToString();
        }
        return "Cannot start the race with zero participants.";
    }

    public void Park(int id)
    {
        foreach (var race in races.Values)
        {
            if (race.Cars.ContainsKey(id))
            {
                return;
            }
        }

        var car = this.cars[id];
        this.garage.ParkCar(id, car);
    }

    public void Unpark(int id)
    {
        this.garage.UnparkCar(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (garage.ParkedCars.Count > 0)
        {
            var parkedCars = garage.ParkedCars;
            foreach (var parkedCar in parkedCars)
            {
                var carName = parkedCar.Value.GetType().Name;
                parkedCar.Value.HorsePower += tuneIndex;
                parkedCar.Value.Suspension += (tuneIndex / 2);
                switch (carName)
                {
                    case "ShowCar":
                        var currentCar = (ShowCar)parkedCar.Value;
                        currentCar.Stars += tuneIndex;
                        break;
                    case "PerformanceCar":
                        var currentCarr = (PerformanceCar)parkedCar.Value;
                        currentCarr.AddOns.Add(addOn);
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
        }
    }
}
