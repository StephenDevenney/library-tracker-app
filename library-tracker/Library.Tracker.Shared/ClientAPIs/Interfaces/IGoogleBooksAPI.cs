using Library.Tracker.Shared.ViewModels;
using System.Threading.Tasks;

namespace Library.Tracker.Shared.ClientAPIs.Interfaces
{
    public interface IGoogleBooksAPI
    {
        #region GET
        public Task<BookViewModel> GetBookByISBN(string isbn);
        #endregion

        #region PUT 

        #endregion

        #region POST

        #endregion
    }
}
