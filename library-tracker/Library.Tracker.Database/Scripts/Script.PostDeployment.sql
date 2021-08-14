/*					
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.	
--------------------------------------------------------------------------------------
*/

-- ENUMS
INSERT INTO [enum].[UserRole] ([UserRoleId], [RoleName])
VALUES (1, N'Admin'),
(2, N'User')

INSERT INTO [enum].[Theme] ([ThemeId], [ThemeName], [ClassName])
VALUES (1, N'Default', N'standard-theme'),
(2, N'Dark', N'dark-theme')

INSERT INTO [enum].[AppIdleSecs] ([AppIdleSecsId], [IdleTime], [Description])
VALUES (1, 10800, N'3 Hours'),
(2, 3600, N'1 Hour'),
(3, 1200, N'20 Minutes'),
(4, 300, N'5 Minutes'),
(5, 60, N'1 Minute'),
(6, 0, N'Off')

INSERT INTO [enum].[NavMenu] ([NavMenuId], [NavMenuName], [NavMenuTitle], [NavMenuRoute]) 
VALUES (1, N'Home', N'Search Books And Comics', N'home'),
(2, N'Books', N'View Books', N'books'),
(3, N'Comics', N'View Comics', N'comics'),
(4, N'Admin', N'Only Admins Can See This', N'admin')

-- SECURITY
INSERT INTO [security].[User] ([UserId], [FK_UserRoleId], [UserName]) 
VALUES (1, 1, N'Stephen'),
(2, 2, N'TestUser')

INSERT INTO [security].[AppSettings] ([AppSettingsId], [FK_UserId], [FK_ThemeId], [FK_AppIdleSecsId], [NavMinimised]) 
VALUES (1, 1, 1, 4, 0),
(2, 2, 1, 3, 0)

INSERT INTO [security].[NavMenuRole] ([NavMenuRoleId], [FK_NavMenuId], [FK_UserRoleId]) 
VALUES (1, 1, 1),
(2, 1, 2),
(3, 2, 1),
(4, 2, 2),
(5, 3, 1),
(6, 3, 2),
(7, 4, 1)