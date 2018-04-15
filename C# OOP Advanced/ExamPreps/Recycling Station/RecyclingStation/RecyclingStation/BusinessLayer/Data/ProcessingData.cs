namespace RecyclingStation.BusinessLayer.Data
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class ProcessingData : IProcessingData
    {
        private double energyBalance;
        private double capitalBalance;

        public ProcessingData(double energyBalance, double capitalBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }

        public double EnergyBalance
        {
            get => energyBalance;
            set => energyBalance = value;
        }

        public double CapitalBalance
        {
            get => capitalBalance;
            set => capitalBalance = value;
        }
    }
}
