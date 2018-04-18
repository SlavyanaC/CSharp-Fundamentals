using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private IGameController gameController;
    private bool isRunnng;

    public Engine(IReader reader, IWriter writer, IGameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
        this.isRunnng = false;
    }

    public void Run()
    {
        this.isRunnng = true;

        while (isRunnng)
        {
            string input = this.reader.ReadLine();
            if (input.Equals(OutputMessages.InputTerminateString))
            {
                isRunnng = false;
                continue;
            }

            try
            {
                this.gameController.ProcessCommand(input);
            }
            catch (ArgumentException arg)
            {
                writer.StoreMessage(arg.Message);
            }
        }

        this.gameController.GetSummary();
        this.writer.WriteLine();
    }
}

