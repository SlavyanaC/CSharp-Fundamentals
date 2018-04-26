namespace StorageMaster.Core
{
    using IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private StorageMaster storageMaster;
        private ConsoleReader consoleReader;
        private ConsoleWriter consoleWriter;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
            this.consoleReader = new ConsoleReader();
            this.consoleWriter = new ConsoleWriter();
        }

        public void Run()
        {
            while (true)
            {
                string input = this.consoleReader.ReadLine();
                if (input == "END")
                {
                    this.consoleWriter.WriteLine(this.storageMaster.GetSummary());
                    break;
                }
                try
                {
                    var result = this.ProcessCommand(input);
                    this.consoleWriter.WriteLine(result);
                }
                catch (InvalidOperationException e)
                {
                    this.consoleWriter.WriteLine($"Error: {e.Message}");
                }
            }
        }

        private string ProcessCommand(string input)
        {
            string[] commandArgs = input.Split();
            string command = commandArgs[0];
            commandArgs = commandArgs.Skip(1).ToArray();

            string result = string.Empty;
            switch (command)
            {
                case "AddProduct":
                    result = this.storageMaster.AddProduct(commandArgs[0], double.Parse(commandArgs[1]));
                    break;
                case "RegisterStorage":
                    result = this.storageMaster.RegisterStorage(commandArgs[0], commandArgs[1]);
                    break;
                case "SelectVehicle":
                    result = this.storageMaster.SelectVehicle(commandArgs[0], int.Parse(commandArgs[1]));
                    break;
                case "LoadVehicle":
                    IEnumerable<string> products = commandArgs;
                    result = this.storageMaster.LoadVehicle(products);
                    break;
                case "SendVehicleTo":
                    result = this.storageMaster.SendVehicleTo(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2]);
                    break;
                case "UnloadVehicle":
                    result = this.storageMaster.UnloadVehicle(commandArgs[0], int.Parse(commandArgs[1]));
                    break;
                case "GetStorageStatus":
                    result = this.storageMaster.GetStorageStatus(commandArgs[0]);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
