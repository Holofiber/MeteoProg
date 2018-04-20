using System;

namespace BussinesLogic.Logger
{
    public static class LoggerFactory
    {
        public static ILogger Create(string loggerType)
        {
            switch (loggerType)
            {
                case "Console":
                    return new ConsoleLogger();
                case "DebugOutput":
                    return new DebugOutputLogger();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
