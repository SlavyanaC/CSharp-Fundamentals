namespace Logger
{
    using Logger.Models.Factories;
    using Logger.Models.Interfaces;
    using System;

    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine())!= "END")
            {
                string[] errorArgs = input.Split('|');
                string level = errorArgs[0];
                string dateTime = errorArgs[1];
                string message = errorArgs[2];

                IError error = this.errorFactory.CreateError(dateTime, level, message);
                this.logger.Log(error);
            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
