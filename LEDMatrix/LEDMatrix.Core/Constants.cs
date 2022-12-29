using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core
{
    public static class Constants
    {
        public static class RMQ
        {
            public const string DEFAULT_EXCHANGE_NAME = "PanelExchange";
            public const string DEFAULT_QUEUE_NAME = "WebAPIQueue";
            public const string HOSTNAME = "10.10.0.241";
            public const string USERNAME = "ledpanel";
            public const string PASSWORD = "ledpanel";
            public const string ROUTING_KEY =
#if DEBUG
                "debug"
#else
            "release"
#endif
                ;
        }
    }
}
