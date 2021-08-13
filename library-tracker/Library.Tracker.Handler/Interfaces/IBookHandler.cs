using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tracker.Handler.Interfaces
{
    public interface IBookHandler
    {
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
