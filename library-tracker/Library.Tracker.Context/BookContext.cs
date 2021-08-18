using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Library.Tracker.Context.Interfaces;
using Library.Tracker.Shared.Entities;
using Library.Tracker.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Tracker.Context
{
    public class BookContext: IBookContext
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

        public async Task<AuthorEntity> GetAuthor(string authorName)
        {
            return await this.sqlContext.Author.Where(x => x.AuthorName == authorName).FirstOrDefaultAsync();
        }
        #endregion

        #region PUT

        #endregion

        #region POST
        public async Task AddBookToCollection(BookViewModel book, string authorIds)
        {
            BookEntity bookToAdd = new BookEntity {
                BookName = book.Title.BookName,
                BookSubTitle = book.Title.BookSubTitle,
                ISBN = book.ISBN,
                Description = book.Description,
                PageCount = book.PageCount,
                ImageLinkSmall = book.ImageLinks.Small,
                ImageLinkStandard = book.ImageLinks.Standard,
                AuthorIds = authorIds
            };

            await this.sqlContext.Book.AddAsync(bookToAdd);
            await this.sqlContext.SaveChangesAsync();
        }

        public async Task<AuthorEntity> AddNewAuthor(string authorName)
        {
            AuthorEntity newAuthor = new AuthorEntity { AuthorName = authorName };
            await this.sqlContext.Author.AddAsync(newAuthor);
            await this.sqlContext.SaveChangesAsync();
            return new AuthorEntity { AuthorId = newAuthor.AuthorId, AuthorName = newAuthor.AuthorName };
        }
        #endregion

        #region OTHER
        public async Task<int> SaveContext()
        {
            return await this.sqlContext.SaveChangesAsync();
        }
        #endregion
    }
}
