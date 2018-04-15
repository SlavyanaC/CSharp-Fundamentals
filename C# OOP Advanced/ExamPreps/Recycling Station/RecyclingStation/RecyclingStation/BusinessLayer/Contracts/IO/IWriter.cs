namespace RecyclingStation.BusinessLayer.Contracts.IO
{
    public interface IWriter
    {
        void GatherOutput(string outPutToGather);

        void WriteOutput();
    }
}
