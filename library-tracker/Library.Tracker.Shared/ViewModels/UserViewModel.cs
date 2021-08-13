using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Tracker.Shared.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string Token { get; set; }
        [Required]
        public UserRoleViewModel UserRole { get; set; }
    }
}
