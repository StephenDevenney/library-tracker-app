using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IGlobals globals;
        public BookContext(SqlContext _sqlRepo, IGlobals _globals)
        {
            this.sqlContext = _sqlRepo;
            this.globals = _globals;
        }
        #endregion

        #region GET
        public async Task<List<BookViewModel>> GetBookCollection()
        {
            UserEntity user = await this.globals.GetCurrentUser();
            return await sqlContext.Book.Where(u => u.UserId == user.UserId).Select(book => new BookViewModel
            {
                Title = new Titles { BookName = book.BookName, BookSubTitle = book.BookSubTitle },
                ISBN = book.ISBN,
                Description = book.Description,
                PageCount = book.PageCount,
                ImageLinks = new ImageLinksObj { Small = book.ImageLinkSmall, Standard = book.ImageLinkStandard }

            }).ToListAsync();
        }

        public async Task<List<string>> GetAuthorsFromIds(string isbn)
        {
            UserEntity user = await this.globals.GetCurrentUser();
            string stringIds = await sqlContext.Book.Where(x => x.UserId == user.UserId && x.ISBN == isbn).Select(x => x.AuthorIds).FirstOrDefaultAsync();
            int[] authorIds = Array.ConvertAll(stringIds.Split(",", StringSplitOptions.RemoveEmptyEntries), int.Parse);
            return sqlContext.Author.Where(x => authorIds.Contains(x.AuthorId)).Select(x => x.AuthorName).ToList();
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
            UserEntity user = await this.globals.GetCurrentUser();
            BookEntity bookToAdd = new BookEntity {
                UserId = user.UserId,
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
