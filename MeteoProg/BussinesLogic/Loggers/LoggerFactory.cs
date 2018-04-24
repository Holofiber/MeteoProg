using System;
using System.Collections.Generic;

namespace BussinesLogic.Loggers
{
    public static class LoggerFactory
    {
        public static ILogger Create(string loggerType, List<ILogger> loggersList = null)
        {
            switch (loggerType)
            {
                case "ConsoleLogger":
                    return new ConsoleLogger();
                case "DebugOutputLogger":
                    return new DebugOutputLogger();
                case "FileLogger":
                    return new FileLogger();
                case "Composite":
                    return new CompositeLogger(loggersList);
                default:
                    throw new InvalidOperationException();
            }
        }
        
    }
}
