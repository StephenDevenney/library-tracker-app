CREATE TABLE [security].[NavMenuRole]
(
	[NavMenuRoleId] INT IDENTITY(1,1) PRIMARY KEY, 
    [FK_NavMenuId] INT NULL, 
    [FK_UserRoleId] INT NULL

    CONSTRAINT [NavMenu_NavMenuId] FOREIGN KEY ([FK_NavMenuId]) REFERENCES [enum].[NavMenu] (NavMenuId)
    CONSTRAINT [NavMenu_User_UserRoleId] FOREIGN KEY ([FK_UserRoleId]) REFERENCES [enum].[UserRole] (UserRoleId)
)
