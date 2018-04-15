namespace RecyclingStation.BsuinessLayer.Core
{
    using BusinessLayer.Contracts.Core;
    using RecyclingStation.BusinessLayer.Contracts.Factories;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class RecyclingMenager : IRecyclingStation
    {
        private const string ProcessingDeniedMessage = "Processing Denied!";
        private const string RequirementsChangedMessage = "Management requirement changed!";
        private const string ProcessGarbageMessageToFormat = "{0} kg of {1} successfully processed!";
        private const string StatusMessageToFormat = "Energy: {0} Capital: {1}";
        private const string FloatingPointNumFormat = "F2";

        private IGarbageProcessor garbageProcessor;
        private IWasteFactory wasteFactory;

        private double capitalBalance;
        private double energyBalance;

        private double minimumEnergyBalance;
        private double minimumCapitalBalance;
        private string typeOfGarbage;

        private bool requirementsAreSet;

        public RecyclingMenager(IGarbageProcessor garbageProcessor, IWasteFactory wasteFactory)
        {
            this.garbageProcessor = garbageProcessor;
            this.wasteFactory = wasteFactory;
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            if (this.requirementsAreSet)
            {
                bool requirimentsAreSatisfied = true;
                if (this.typeOfGarbage == type)
                {
                    requirimentsAreSatisfied = this.capitalBalance >= this.minimumCapitalBalance &&
                        this.energyBalance >= this.minimumEnergyBalance;
                }

                if (!requirimentsAreSatisfied)
                {
                    return ProcessingDeniedMessage;
                }
            }
            
            IWaste someWaste = this.wasteFactory.Create(name, weight, volumePerKg, type);

            IProcessingData processedData = this.garbageProcessor.ProcessWaste(someWaste);

            this.capitalBalance += processedData.CapitalBalance;
            this.energyBalance += processedData.EnergyBalance;

            string formattedMessage = string.Format(ProcessGarbageMessageToFormat,
                someWaste.Weight.ToString(FloatingPointNumFormat),
                someWaste.Name);

            return formattedMessage;
        }

        public string ChangeManagementRequirement(double minimumEnergyBalance, double minimumCapitalBalance, string typeOfGarbage)
        {
            this.minimumEnergyBalance = minimumEnergyBalance;
            this.minimumCapitalBalance = minimumCapitalBalance;
            this.typeOfGarbage = typeOfGarbage;

            this.requirementsAreSet = true;
            return RequirementsChangedMessage;
        }

        public string Status()
        {
            string formattedMessage = string.Format(StatusMessageToFormat,
                this.energyBalance.ToString(FloatingPointNumFormat),
                this.capitalBalance.ToString(FloatingPointNumFormat));

            return formattedMessage;
        }
    }
}
