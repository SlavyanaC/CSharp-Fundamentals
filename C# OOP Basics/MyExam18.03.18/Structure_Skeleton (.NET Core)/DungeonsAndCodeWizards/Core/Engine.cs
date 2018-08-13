using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;
        private bool isRunning;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
            this.isRunning = true;
        }

        public void Run()
        {
            while (isRunning)
            {
                if (this.dungeonMaster.IsGameOver())
                {
                    Console.WriteLine("Final stats:");
                    Console.WriteLine(this.dungeonMaster.GetStats());
                    isRunning = false;
                    break;
                }

                string input = Console.ReadLine();
                if (input != string.Empty)
                {
                    try
                    {
                        string[] args = input.Split();
                        string result = this.ProcessCommand(args);
                        Console.WriteLine(result);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine($"Parameter Error: {ae.Message}");
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine($"Invalid Operation: {ioe.Message}");
                    }
                }
                if (string.IsNullOrWhiteSpace(input))
                {
                    isRunning = false;
                    break;
                }
            }
        }

        private string ProcessCommand(string[] args)
        {
            string methodToInvokeName = args[0];
            MethodInfo method = this.dungeonMaster.GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name == methodToInvokeName);

            args = args.Skip(1).ToArray();
            string result = "";
            try
            {
                result = (string)method.Invoke(this.dungeonMaster, new object[] { args });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }

            return result;
        }
    }
}
