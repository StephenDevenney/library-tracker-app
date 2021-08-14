using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Tracker.Shared.ViewModels
{
    public class UserSettingsViewModel
    {
        public UserViewModel User { get; set; }
        public ThemeViewModel Theme { get; set; }
        public AppIdleSecsViewModel AppIdleSecs { get; set; }
        public bool NavMinimized { get; set; }
    }
}
