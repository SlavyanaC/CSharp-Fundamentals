using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder outputGatherer;

    public ConsoleWriter()
    {
        this.outputGatherer = new StringBuilder();
    }

    //public ConsoleWriter(StringBuilder outputGatherer)
    //    : this()
    //{
    //    this.OutputGatherer = outputGatherer;
    //}

    public string StoredMessage
    {
        get => this.outputGatherer.ToString();
    }

    public void StoreMessage(string outPutToGather)
    {
        this.outputGatherer.AppendLine(outPutToGather.Trim());
    }

    public void WriteLine()
    {
        Console.Write(this.outputGatherer);
    }
}