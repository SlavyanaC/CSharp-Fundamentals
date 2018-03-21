namespace Logger.Models.Factories
{
    using System;
    using Logger.Models.Interfaces;

    public class AppenderFactory
    {
        const string DefaultFileName = "logFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = new LayoutFactory();
            this.fileNumber = 0;
        }

        public IAppender CreateAppender(string appenderType, string levelString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ParseErrorLevel(levelString);

            IAppender appender = null;
            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumber));
                    appender = new FileAppender(layout, errorLevel, logFile);
                    break;
                default:
                    throw new ArgumentException("Invalid Appender Type");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string levelString)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!", e);
            }
        }
    }
}
