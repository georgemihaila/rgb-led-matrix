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
            public const string DEFAULT_EXCHANGE_NAME =
#if DEBUG
                "PanelExchange"
#else
            "PanelReleaseExchange"
#endif
            ;
            public const string DEFAULT_QUEUE_NAME =
#if DEBUG
                "WebAPIQueue"
#else
            "WebAPIReleaseQueue"
#endif
            ;
            public const string HOSTNAME = "10.10.0.241";
            public const string USERNAME =
#if DEBUG
                "ledpanel"
#else
            "ledpanelrelease"
#endif
            ;
            public const string PASSWORD = "ledpanel";
            public const string ROUTING_KEY =
#if DEBUG
                "WebAPIQueue"
#else
            "WebAPIReleaseQueue"
#endif
                ;
        }
    }
}
