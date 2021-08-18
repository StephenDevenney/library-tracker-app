CREATE TABLE [enum].[AppIdleSecs]
(
	[AppIdleSecsId] INT IDENTITY(1,1) PRIMARY KEY,
	[IdleTime] INT NOT NULL, 
	[Description] NVARCHAR(50) NOT NULL
)
