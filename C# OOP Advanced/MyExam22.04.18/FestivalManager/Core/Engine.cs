using System;
using System.Linq;

namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private const string LetsRockCommand = "LetsRock";
        private const string TermineteCommand = "END";
        private const string MethodForResults = "ProduceReport";
        private const string Error = "ERROR: ";

        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;
        private bool isRunnign;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setController;
            isRunnign = true;
        }

        public void Run()
        {
            while (isRunnign)
            {
                var input = this.reader.ReadLine();
                if (input.Equals(TermineteCommand))
                {
                    isRunnign = false;
                    break;
                }
                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine($"{Error} + {string.Format(Output.ErrorMsgFormat, ex.InnerException)}");
                }
            }

            string endResult = this.GetEndResult();
            this.writer.WriteLine(endResult);
        }

        public string ProcessCommand(string input)
        {
            var inputArgs = input.Split();
            var command = inputArgs[0];
            if (command.Equals(LetsRockCommand))
            {
                var result = this.setCоntroller.PerformSets();
                return result;
            }

            MethodInfo methodToInvoke = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name.Equals(command));

            inputArgs = inputArgs.Skip(1).ToArray();
            try
            {
                var result = methodToInvoke.Invoke(this.festivalCоntroller, new object[] { inputArgs });
                return result.ToString();
            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
        }

        private string GetEndResult()
        {
            var resultMethod = MethodForResults;
            MethodInfo methodToInvoke = this.festivalCоntroller.GetType()
                   .GetMethods()
                   .FirstOrDefault(m => m.Name.Equals(resultMethod));

            var result = methodToInvoke.Invoke(this.festivalCоntroller, null);
            return result.ToString();
        }
    }
}