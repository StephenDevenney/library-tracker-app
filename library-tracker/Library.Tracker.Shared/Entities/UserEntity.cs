using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Tracker.Shared.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string UserName { get; set; }
    }
}
