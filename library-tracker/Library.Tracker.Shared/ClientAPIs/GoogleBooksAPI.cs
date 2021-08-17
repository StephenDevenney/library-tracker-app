using Library.Tracker.Shared.ClientAPIs.Interfaces;
using Library.Tracker.Shared.Entities;
using Library.Tracker.Shared.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using static Library.Tracker.Shared.Entities.BookEntity;

namespace Library.Tracker.Shared.ClientAPIs
{
    public class GoogleBooksAPI: IGoogleBooksAPI
    {
        #region CONSTRUCTOR
        private readonly HttpClient httpClient;
        public GoogleBooksAPI(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;

        }
        #endregion

        #region GET
        public async Task<BookViewModel> GetBookByISBN(string isbn)
        {
            if (isbn.Length == 0)
                return null;

            var responseString = await httpClient.GetStringAsync(new System.Uri("https://www.googleapis.com/books/v1/volumes?q=isbn:" + isbn));
            BookEntity bookE = JsonConvert.DeserializeObject<BookEntity>(responseString);
            if (bookE == null || bookE.Items.Length == 0)
                return null;

            Volumeinfo bookInfo = bookE.Items[0].VolumeInfo;
            if (bookInfo.ImageLinks == null)
                bookInfo.ImageLinks = new Imagelinks { Thumbnail = "", SmallThumbnail = "" };

            BookViewModel bookVM = new BookViewModel {
                Title = new Titles { BookName = bookInfo.Title ?? "", BookSubTitle = bookInfo.Subtitle ?? "" } ?? new Titles { BookName = "", BookSubTitle = ""},
                ISBN = bookInfo.IndustryIdentifiers[1].Identifier ?? "",
                Authors = (string[])bookInfo.Authors ?? new string[] { },
                Description = bookInfo.Description ?? "",
                PageCount = bookInfo.PageCount ?? 0,
                ImageLinks = new ImageLinksObj { Standard = bookInfo.ImageLinks.Thumbnail ?? "", Small = bookInfo.ImageLinks.SmallThumbnail ?? ""},
            };
            return bookVM;
        }
        #endregion

        #region PUT

        #endregion

        #region POST

        #endregion
    }
}
