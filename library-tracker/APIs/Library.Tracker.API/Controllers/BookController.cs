using Library.Tracker.Handler.Interfaces;
using Library.Tracker.Shared.ClientAPIs.Interfaces;
using Library.Tracker.Shared.Security;
using Library.Tracker.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Tracker.API.Controllers
{
    [Route("Book")]
    public class BookController : ControllerBase
    {
        #region CONSTRUCTOR
        private readonly IBookHandler bookHandler;
        public BookController(IBookHandler bookHandler)
        {
            this.bookHandler = bookHandler;
        }
        #endregion

        #region GET
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpGet("book-isbn/{isbn}")]
        public async Task<BookViewModel> GetBookByISBN(string isbn) => await bookHandler.GetBookFromISBN(isbn);
        #endregion

        #region PUT

        #endregion

        #region POST
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpPost("add")]
        public async Task AddBookToCollection([FromBody] BookViewModel book) => await bookHandler.AddBookToCollection(book);
        #endregion
    }
}
