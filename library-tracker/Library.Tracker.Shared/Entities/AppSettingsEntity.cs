using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Tracker.Shared.Entities
{
    public class AppSettingsEntity
    {
        public int AppSettingsId { get; set; }
        public int UserId { get; set; }
        public int ThemeId { get; set; }
        public int AppIdleSecsId { get; set; }
        public bool NavMinimised { get; set; }
    }
}
