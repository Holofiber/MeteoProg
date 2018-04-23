using System;
using System.Collections.Generic;

namespace BussinesLogic.Logger
{
    public static class LoggerFactory
    {
        public static ILogger Create(string loggerType, List<ILogger> loggerTyps = null)
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
                    return new CompositeLogger(loggerTyps);
                default:
                    throw new InvalidOperationException();
            }
        }
        
    }
}
