using System;
using System.Collections.Generic;
using System.Text;
using BussinesLogic.Loggers;

namespace BussinesLogic
{
    public class ApplicationSettings
    {
        public string ProviderName { get; set; }

        public string LoggerTyppe { get; set; }

        public List<string> CompositionLoggers { get; set; }

        public string LoggerFileName { get; set; }
    }
}
