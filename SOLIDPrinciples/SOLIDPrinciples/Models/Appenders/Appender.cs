namespace SOLIDPrinciples.Models.Appenders
{
    using System;

    using SOLIDPrinciples.Contracts;

    public abstract class Appender:IAppender
    {
        public Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel=ReportLevel.Info;
        }

        public ReportLevel ReportLevel { get; set; }

        public ILayout Layout { get; set; }

        public abstract void Append(DateTime date, ReportLevel level, string message);

        public string GetFormatedLog(DateTime date, ReportLevel level, string message)
        {
            return this.Layout.FormatLog(date, level, message);
        }
    }
}
