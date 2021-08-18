using Library.Tracker.Shared.Entities;
using Library.Tracker.Shared.ViewModels;
using System.Threading.Tasks;

namespace Library.Tracker.Context.Interfaces
{
    public interface IBookContext
    {
        #region GET
        public Task<AuthorEntity> GetAuthor(string authorName);
        #endregion

        #region PUT

        #endregion

        #region POST
        public Task AddBookToCollection(BookViewModel book, string authorIds);
        public Task<AuthorEntity> AddNewAuthor(string authorName);
        #endregion

        #region OTHER
        public Task<int> SaveContext();
        #endregion
    }
}
