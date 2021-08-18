using Library.Tracker.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Tracker.Handler.Interfaces
{
    public interface IBookHandler
    {
        #region GET
        public Task<BookViewModel> GetBookFromISBN(string isbn);
        public Task<List<BookViewModel>> GetBookCollection();
        #endregion

        #region PUT

        #endregion

        #region POST
        public Task AddBookToCollection(BookViewModel book);
        #endregion
    }
}
