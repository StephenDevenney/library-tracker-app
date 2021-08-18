using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Tracker.Context.Interfaces;
using Library.Tracker.Handler.Interfaces;
using Library.Tracker.Shared.ClientAPIs.Interfaces;
using Library.Tracker.Shared.Entities;
using Library.Tracker.Shared.ViewModels;

namespace Library.Tracker.Handler
{
    public class BookHandler : IBookHandler
    {
        #region CONSTRUCTOR
        private readonly IBookContext bookRepo;
        private readonly IGoogleBooksAPI googleBooksAPI;
        public BookHandler(IBookContext _bookRepo, IGoogleBooksAPI _googleBooksAPI)
        {
            this.bookRepo = _bookRepo;
            this.googleBooksAPI = _googleBooksAPI;
        }
        #endregion
        
        #region GET
        public async Task<BookViewModel> GetBookFromISBN(string isbn) => await googleBooksAPI.GetBookByISBN(isbn);
        public async Task<List<BookViewModel>> GetBookCollection()
        {
            List<BookViewModel> bookCollection = await bookRepo.GetBookCollection();

            foreach(BookViewModel book in bookCollection)
            {
                book.Authors = await bookRepo.GetAuthorsFromIds(book.ISBN);
            }

            return bookCollection;
        }
        #endregion

        #region PUT

        #endregion

        #region POST
        public async Task AddBookToCollection(BookViewModel book)
        {
            string authorIds = "";
            foreach (string authorName in book.Authors)
            {
                AuthorEntity authorE = await bookRepo.GetAuthor(authorName);
                if(authorE == null)
                    authorE = await bookRepo.AddNewAuthor(authorName);

                authorIds += authorE.AuthorId + ",";
            }
            await bookRepo.AddBookToCollection(book, authorIds);
            await bookRepo.SaveContext();
        }
            #endregion

        }
}
