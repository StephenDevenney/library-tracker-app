using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Tracker.Shared.Security
{
    public class AppSettings
    {
        public string PortalUrl { get; set; }
        public string PortalUrlCors { get; set; }
        public string Environment { get; set; }
        public string Secret { get; set; }
    }
}
