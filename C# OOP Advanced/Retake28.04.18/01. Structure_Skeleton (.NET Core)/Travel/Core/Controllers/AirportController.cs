namespace Travel.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Airplanes.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    public class AirportController : IAirportController
    {
        private const int BagValueConfiscationThreshold = 3000;

        private readonly IAirport airport;
        private readonly IAirplaneFactory airplaneFactory;
        private readonly IItemFactory itemFactory;

        public AirportController(IAirport airport)
        {
            this.airport = airport;

            this.airplaneFactory = new AirplaneFactory();
            this.itemFactory = new ItemFactory();
        }

        public string RegisterPassenger(string username)
        {
            if (this.airport.GetPassenger(username) != null)
            {
                throw new InvalidOperationException(string.Format(Constants.PassengerAlreadyRegistered, username));
            }

            IPassenger passenger = new Passenger(username);
            this.airport.AddPassenger(passenger);
            return string.Format(Constants.RegisterPassenger, passenger.Username);
        }

        public string RegisterBag(string username, IEnumerable<string> bagItems)
        {
            IPassenger passenger = this.airport.GetPassenger(username);
            IItem[] items = bagItems.Select(i => this.itemFactory.CreateItem(i)).ToArray();
            IBag bag = new Bag(passenger, items);
            passenger.Bags.Add(bag);
            return string.Format(Constants.RegisterBag, string.Join(", ", bagItems), username);
        }

        public string RegisterTrip(string source, string destination, string planeType)
        {
            IAirplane airplane = this.airplaneFactory.CreateAirplane(planeType);
            ITrip trip = new Trip(source, destination, airplane);
            this.airport.AddTrip(trip);
            return string.Format(Constants.RegisterTrip, trip.Id);
        }

        public string CheckIn(string username, string tripId, IEnumerable<int> bagIndices)
        {
            IPassenger passenger = this.airport.GetPassenger(username);
            ITrip trip = this.airport.GetTrip(tripId);

            bool checkedIn = this.airport.Trips.Any(t => t.Airplane.Passengers.Any(p => p.Username == username));

            if (checkedIn)
            {
                throw new InvalidOperationException(string.Format(Constants.UserAlreadyCheckedIn, username));
            }

            int confiscatedBags = CheckInBags(passenger, bagIndices);
            trip.Airplane.AddPassenger(passenger);

            return string.Format(Constants.CheckIn, passenger.Username, bagIndices.Count() - confiscatedBags, bagIndices.Count());
        }

        private int CheckInBags(IPassenger passenger, IEnumerable<int> bagsToCheckIndices)
        {
            //IList<IBag> bags = passenger.Bags;
            int confiscatedBagsCount = 0;
            foreach (var index in bagsToCheckIndices)
            {
                IBag currentBag = passenger.Bags[index];
                passenger.Bags.RemoveAt(index);
                if (ShouldConfiscate(currentBag))
                {
                    this.airport.AddConfiscatedBag(currentBag);
                    confiscatedBagsCount++;
                }
                else
                {
                    this.airport.AddCheckedBag(currentBag);
                }
            }

            return confiscatedBagsCount;
        }

        private static bool ShouldConfiscate(IBag bag)
        {
            var luggageValue = 0;
            foreach (var item in bag.Items)
            {
                luggageValue += item.Value;
            }

            bool shouldConfiscate = luggageValue > BagValueConfiscationThreshold;
            return shouldConfiscate;
        }
    }
}