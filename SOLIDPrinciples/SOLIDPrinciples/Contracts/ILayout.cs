namespace SOLIDPrinciples.Contracts
{
    using System;
    using SOLIDPrinciples.Models;

    public interface ILayout
    {
        string FormatLog(DateTime data, ReportLevel reportLevel, string message);
    }
}
