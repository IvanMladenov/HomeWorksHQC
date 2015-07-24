namespace SOLIDPrinciples.Contracts
{
    using System;

    using SOLIDPrinciples.Models;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        ILayout Layout { get; set; }

        void Append(DateTime date, ReportLevel level, string message);
    }
}
