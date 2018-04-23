using System.Collections.Generic;

namespace BussinesLogic.Logger
{
    public class CompositeLogger : ILogger
    {
        private readonly List<ILogger> name;
        List<ILogger> loggers = new List<ILogger>();

        public CompositeLogger(List<ILogger> name)
        {
            this.name = name;
        }

       

        public void Info(string message = "")
        {
            foreach (var logger in name)
            {
                logger.Info(message);
            }
        }

        public void Warning(string message = "")
        {
            foreach (var logger in name)
            {
                logger.Warning(message);
            }
        }

        public void Error(string message = "")
        {
            foreach (var logger in name)
            {
                logger.Error(message);
            }
        }
    }
}