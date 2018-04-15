namespace RecyclingStation.BusinessLayer.Entities.Garbages
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public abstract class Garbage : IWaste
    {
        private string name;
        private double volumePerKg;
        private double weight;

        public Garbage(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }
        public double VolumePerKg
        {
            get => volumePerKg;
            private set => volumePerKg = value;
        }

        public double Weight
        {
            get => weight;
            private set => weight = value;
        }
    }
}
