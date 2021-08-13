using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Tracker.Shared.Security
{
    public class AppSettings
    {
        public string PortUrl { get; set; }
        public string PortUrlCors { get; set; }
        public string Enviroment { get; set; }
        public string Secret { get; set; }
    }
}
