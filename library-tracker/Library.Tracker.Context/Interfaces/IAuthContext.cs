﻿using Library.Tracker.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tracker.Context.Interfaces
{
    public interface IAuthContext
    {
        public Task<UserViewModel> Authenticate(string username);
        public Task<List<UserViewModel>> GetAllUsers();
        public Task<UserViewModel> GetUserById(int userId);
    }
}