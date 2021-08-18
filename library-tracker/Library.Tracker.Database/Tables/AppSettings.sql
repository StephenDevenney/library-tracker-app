CREATE TABLE [security].[AppSettings]
(
	[AppSettingsId] INT IDENTITY(1,1) PRIMARY KEY,
	[FK_UserId] INT NOT NULL, 
	[FK_ThemeId] INT NOT NULL DEFAULT 1, 
	[FK_AppIdleSecsId] INT NOT NULL,
	[NavMinimised] BIT NOT NULL, 

	CONSTRAINT [User_UserId] FOREIGN KEY ([FK_UserId]) REFERENCES [security].[User] (UserId),
	CONSTRAINT [Theme_ThemeId] FOREIGN KEY ([FK_ThemeId]) REFERENCES [enum].[Theme] (ThemeId),
	CONSTRAINT [AppIdleSecs_AppIdleSecsId] FOREIGN KEY ([FK_AppIdleSecsId]) REFERENCES [enum].[AppIdleSecs] (AppIdleSecsId)
)
