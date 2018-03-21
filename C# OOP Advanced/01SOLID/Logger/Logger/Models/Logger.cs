namespace Logger.Models
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class Loger : ILogger
    {
        IEnumerable<IAppender> appenders;

        public Loger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;
        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders.Where(a => a.Level <= error.Level))
            {
                appender.Append(error);
            }
        }
    }
}
