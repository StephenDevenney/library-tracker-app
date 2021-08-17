
namespace Library.Tracker.Shared.Entities
{
    public class BookEntity
    {
        #nullable enable
        /*
         * Generated From JSON
        */
        public string? Kind { get; set; }
        public int? TotalItems { get; set; }
        public Item[]? Items { get; set; }

        public class Item
        {
            public string? Kind { get; set; }
            public string? Id { get; set; }
            public string? Etag { get; set; }
            public string? SelfLink { get; set; }
            public Volumeinfo? VolumeInfo { get; set; }
            public Saleinfo? SaleInfo { get; set; }
            public Accessinfo? AccessInfo { get; set; }
            public Searchinfo? SearchInfo { get; set; }
        }

        public class Volumeinfo
        {
            public string? Title { get; set; }
            public string? Subtitle { get; set; }
            public string[]? Authors { get; set; }
            public string? Publisher { get; set; }
            public string? PublishedDate { get; set; }
            public string? Description { get; set; }
            public Industryidentifier[]? IndustryIdentifiers { get; set; }
            public Readingmodes? ReadingModes { get; set; }
            public int? PageCount { get; set; }
            public string? PrintType { get; set; }
            public string[]? Categories { get; set; }
            public decimal? AverageRating { get; set; }
            public int? RatingsCount { get; set; }
            public string? MaturityRating { get; set; }
            public bool? AllowAnonLogging { get; set; }
            public string? ContentVersion { get; set; }
            public Panelizationsummary? PanelizationSummary { get; set; }
            public Imagelinks? ImageLinks { get; set; }
            public string? Language { get; set; }
            public string? PreviewLink { get; set; }
            public string? InfoLink { get; set; }
            public string? CanonicalVolumeLink { get; set; }
        }

        public class Readingmodes
        {
            public bool? Text { get; set; }
            public bool? Image { get; set; }
        }

        public class Panelizationsummary
        {
            public bool? ContainsEpubBubbles { get; set; }
            public bool? ContainsImageBubbles { get; set; }
        }

        public class Imagelinks
        {
            public string? SmallThumbnail { get; set; }
            public string? Thumbnail { get; set; }
        }

        public class Industryidentifier
        {
            public string? Type { get; set; }
            public string? Identifier { get; set; }
        }

        public class Saleinfo
        {
            public string? Country { get; set; }
            public string? Saleability { get; set; }
            public bool? IsEbook { get; set; }
        }

        public class Accessinfo
        {
            public string? Country { get; set; }
            public string? Viewability { get; set; }
            public bool? Embeddable { get; set; }
            public bool? PublicDomain { get; set; }
            public string? TextToSpeechPermission { get; set; }
            public Epub? Epub { get; set; }
            public Pdf? Pdf { get; set; }
            public string? WebReaderLink { get; set; }
            public string? AccessViewStatus { get; set; }
            public bool? QuoteSharingAllowed { get; set; }
        }

        public class Epub
        {
            public bool? IsAvailable { get; set; }
        }

        public class Pdf
        {
            public bool? IsAvailable { get; set; }
        }

        public class Searchinfo
        {
            public string? TextSnippet { get; set; }
        }
        #nullable disable
    }
}
