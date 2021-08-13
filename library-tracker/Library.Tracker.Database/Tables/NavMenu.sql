CREATE TABLE [security].[NavMenu]
(
	[NavMenuId] INT NOT NULL PRIMARY KEY, 
    [NavMenuName] NVARCHAR(50) NOT NULL, 
    [NavMenuTitle] NVARCHAR(50) NULL, 
    [NavMenuRoute] NVARCHAR(50) NULL
)
