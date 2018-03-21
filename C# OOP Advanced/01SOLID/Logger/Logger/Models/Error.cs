namespace Logger.Models
{
    using Interfaces;
    using System;

    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Mesage = message;
        }

        public DateTime DateTime { get; }

        public ErrorLevel Level { get; }

        public string Mesage { get; }
    }
}
