
namespace Library.Tracker.Shared.Entities
{
    public class BookEntity
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookSubTitle { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string ImageLinkSmall { get; set; }
        public string ImageLinkStandard { get; set; }
        public string AuthorIds { get; set; }
    }
}
