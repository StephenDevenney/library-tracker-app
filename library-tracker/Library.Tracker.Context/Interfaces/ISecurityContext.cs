using Library.Tracker.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tracker.Context.Interfaces
{
    public interface ISecurityContext
    {
        public Task<List<NavMenuViewModel>> GetNavMenu();
    }
}
