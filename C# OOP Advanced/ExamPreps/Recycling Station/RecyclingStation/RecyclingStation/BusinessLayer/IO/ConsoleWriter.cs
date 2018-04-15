namespace RecyclingStation.BusinessLayer.IO
{
    using RecyclingStation.BusinessLayer.Contracts.IO;
    using System;
    using System.Text;

    public class ConsoleWriter : IWriter
    {
        private StringBuilder outputGatherer;

        public ConsoleWriter()
        {
            this.OutputGatherer = new StringBuilder();
        }

        public ConsoleWriter(StringBuilder outputGatherer)
            : this()
        {
            this.OutputGatherer = outputGatherer;
        }

        public StringBuilder OutputGatherer
        {
            get => this.outputGatherer;
            private set => this.outputGatherer = value;
        }

        public void GatherOutput(string outPutToGather)
        {
            this.OutputGatherer.AppendLine(outPutToGather);
        }

        public void WriteOutput()
        {
            Console.Write(this.OutputGatherer);
        }
    }
}
