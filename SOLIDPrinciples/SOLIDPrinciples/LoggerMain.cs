namespace SOLIDPrinciples
{
    using SOLIDPrinciples.Models;
    using SOLIDPrinciples.Models.Appenders;
    using SOLIDPrinciples.Models.Layouts;

    internal class LoggerMain
    {
        private static void Main()
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);
            var logger = new Logger(consoleAppender);

            logger.Fatal("mscorlib.dll does not respond");
            logger.Critical("No connection string found in App.config");
        }
    }
}