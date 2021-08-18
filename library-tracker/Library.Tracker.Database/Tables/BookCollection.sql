CREATE TABLE [book].[BookCollection]
(
	[BookId] INT IDENTITY(1,1) PRIMARY KEY, 
    [BookName] NVARCHAR(50) NOT NULL, 
    [BookSubTitle] NVARCHAR(50) NOT NULL, 
    [ISBN] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [PageCount] INT NOT NULL,
    [ImageLinkSmall] NVARCHAR(MAX) NOT NULL, 
    [ImageLinkStandard] NVARCHAR(MAX) NOT NULL, 
    [AuthorIds] NVARCHAR(50) NOT NULL
)
