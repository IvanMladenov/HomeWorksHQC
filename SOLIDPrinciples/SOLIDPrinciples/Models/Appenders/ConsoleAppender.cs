namespace SOLIDPrinciples.Models.Appenders
{
    using System;

    using SOLIDPrinciples.Contracts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(DateTime date, ReportLevel level, string message)
        {
            if (level >= this.ReportLevel)
            {
                string formatedLog = this.GetFormatedLog(date, level, message);
                Console.Write(formatedLog);
            }
        }
    }
}