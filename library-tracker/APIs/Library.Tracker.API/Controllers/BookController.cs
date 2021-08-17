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
        private readonly IGoogleBooksAPI googleBooksAPI;
        public BookController(IGoogleBooksAPI _googleBooksAPI)
        {
            this.googleBooksAPI = _googleBooksAPI;
        }
        #endregion

        #region GET
        [Authorize(Roles = SecureRole.Admin + "," + SecureRole.User)]
        [HttpGet("book-isbn/{isbn}")]
        public async Task<BookViewModel> GetBookByISBN(string isbn) => await googleBooksAPI.GetBookByISBN(isbn);
        #endregion
    }
}
