CREATE TABLE [security].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [FK_UserRoleId] INT NOT NULL, 
    [UserName] NVARCHAR(50) NOT NULL

    CONSTRAINT [User_Role_UserRoleId] FOREIGN KEY ([FK_UserRoleId]) REFERENCES [enum].[UserRole] (UserRoleId)
)
