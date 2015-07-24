namespace SOLIDPrinciples.Models.Layouts
{
    using System;

    using SOLIDPrinciples.Contracts;

    public class SimpleLayout : ILayout
    {
        public string FormatLog(DateTime data, ReportLevel reportLevel, string message)
        {
            string outputLogFormated = string.Format("{0} - {1} - {2}", data, reportLevel, message)
                                       + Environment.NewLine;
            return outputLogFormated;
        }
    }
}
