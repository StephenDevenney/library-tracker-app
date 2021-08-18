/*					
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.	
--------------------------------------------------------------------------------------
*/

-- ENUMS
INSERT INTO [enum].[UserRole] ([RoleName])
VALUES (N'Admin'),
(N'User')

INSERT INTO [enum].[Theme] ([ThemeName], [ClassName])
VALUES (N'Default', N'standard-theme'),
(N'Dark', N'dark-theme')

INSERT INTO [enum].[AppIdleSecs] ([IdleTime], [Description])
VALUES (10800, N'3 Hours'),
(3600, N'1 Hour'),
(1200, N'20 Minutes'),
(300, N'5 Minutes'),
(60, N'1 Minute'),
(0, N'Off')

INSERT INTO [enum].[NavMenu] ([NavMenuName], [NavMenuTitle], [NavMenuRoute]) 
VALUES (N'Home', N'Search Books And Comics', N'home'),
(N'Books', N'View Books', N'books'),
(N'Comics', N'View Comics', N'comics'),
(N'Admin', N'Only Admins Can See This', N'admin')

-- SECURITY
INSERT INTO [security].[User] ([FK_UserRoleId], [UserName]) 
VALUES (1, N'Stephen'),
(2, N'TestUser')

INSERT INTO [security].[AppSettings] ([FK_UserId], [FK_ThemeId], [FK_AppIdleSecsId], [NavMinimised]) 
VALUES (1, 1, 4, 0),
(2, 1, 3, 0)

INSERT INTO [security].[NavMenuRole] ([FK_NavMenuId], [FK_UserRoleId]) 
VALUES (1, 1),
(1, 2),
(2, 1),
(2, 2),
(3, 1),
(3, 2),
(4, 1)