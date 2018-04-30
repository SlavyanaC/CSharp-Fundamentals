namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Core;
    using Entities.Contracts;

    public abstract class Airplane : IAirplane
    {
        private IList<IBag> baggageCompartment;

        private IList<IPassenger> passengers;

        protected Airplane(int seats, int baggageCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;

            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public int Seats { get; }

        public int BaggageCompartments { get; }

        public bool IsOverbooked => this.passengers.Count > this.Seats;

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.ToList().AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.ToList().AsReadOnly();

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seat)
        {
            IPassenger passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);
            return passenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            IBag[] bags = this.baggageCompartment.Where(b => b.Owner == passenger).ToArray();
            foreach (var bag in bags)
            {
                this.baggageCompartment.Remove(bag);
            }

            return bags;
        }

        public void LoadBag(IBag bag)
        {
            if (this.baggageCompartment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException(string.Format(Constants.NoRoom, this.GetType().Name));
            }

            this.baggageCompartment.Add(bag);
        }
    }
}
