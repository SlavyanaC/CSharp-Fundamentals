namespace Travel.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Airport : IAirport
    {
        private IList<IBag> checkedInBags;
        private IList<IBag> confiscatedBags;
        private IList<IPassenger> passengers;
        private IList<ITrip> trips;

        public Airport()
        {
            this.checkedInBags = new List<IBag>();
            this.confiscatedBags = new List<IBag>();
            this.passengers = new List<IPassenger>();
            this.trips = new List<ITrip>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => this.checkedInBags.ToList().AsReadOnly();

        public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags.ToList().AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.ToList().AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => this.trips.ToList().AsReadOnly();

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public void AddTrip(ITrip trip)
        {
            this.trips.Add(trip);
        }

        public void AddCheckedBag(IBag bag)
        {
            this.checkedInBags.Add(bag);
        }

        public void AddConfiscatedBag(IBag bag)
        {
            this.confiscatedBags.Add(bag);
        }

        public IPassenger GetPassenger(string username)
        {
            IPassenger passenger = this.passengers.FirstOrDefault(p => p.Username == username);
            return passenger;
        }

        public ITrip GetTrip(string id)
        {
            ITrip trip = this.trips.FirstOrDefault(t => t.Id == id);
            return trip;
        }
    }
}