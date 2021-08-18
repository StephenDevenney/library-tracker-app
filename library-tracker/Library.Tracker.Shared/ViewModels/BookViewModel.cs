
using System.Collections.Generic;

namespace Library.Tracker.Shared.ViewModels
{
    public class BookViewModel
    {
        public Titles Title { get; set; }
        public List<string> Authors { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public ImageLinksObj ImageLinks { get; set; }
    }

    public class Titles
    {
        public string BookName { get; set; }
        public string BookSubTitle { get; set; }
    }

    public class ImageLinksObj 
    { 
        public string Small { get; set; }
        public string Standard { get; set; }
    }

}
