namespace SOLIDPrinciples.Models.Layouts
{
    using System;
    using System.Text;

    using SOLIDPrinciples.Contracts;

    public class XmlLayout : ILayout
    {
        private const int NumberOfSpaces = 3;

        private readonly string indentation = new string(' ', NumberOfSpaces);

        public string FormatLog(DateTime data, ReportLevel reportLevel, string message)
        {
            StringBuilder formatedLog = new StringBuilder();
            formatedLog.AppendLine("<log>");
            formatedLog.AppendLine(string.Format("{1}<date>{0}</date>", data, this.indentation));
            formatedLog.AppendLine(string.Format("{1}<level>{0}</level>", reportLevel, this.indentation));
            formatedLog.AppendLine(string.Format("{1}<message>{0}</message>", message, this.indentation));
            formatedLog.AppendLine("</log>");

            return formatedLog.ToString();
        }
    }
}