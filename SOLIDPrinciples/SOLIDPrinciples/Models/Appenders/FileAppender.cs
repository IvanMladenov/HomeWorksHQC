namespace SOLIDPrinciples.Models.Appenders
{
    using System;

    using SOLIDPrinciples.Contracts;

    internal class FileAppender : Appender
    {
        public FileAppender(ILayout layout)
            : base(layout)
        {
        }

        public string File { get; set; }

        public override void Append(DateTime date, ReportLevel level, string message)
        {
            if (level >= this.ReportLevel)
            {
                string formatedLog = this.GetFormatedLog(date, level, message);
                System.IO.File.AppendAllText(this.File, formatedLog);
            }
        }
    }
}