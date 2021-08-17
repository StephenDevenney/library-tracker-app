using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Library.Tracker.Context.Interfaces;
using Library.Tracker.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Tracker.Context
{
    public class BookContext
    {
        #region CONSTRUCTOR
        private readonly SqlContext sqlContext;
        public BookContext(SqlContext _sqlRepo)
        {
            this.sqlContext = _sqlRepo;
        }
        #endregion

        #region GET
        public void GetBook()
        {

        }
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
