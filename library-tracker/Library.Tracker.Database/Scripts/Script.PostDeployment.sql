/*					
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.	
--------------------------------------------------------------------------------------
*/

-- ENUMS
INSERT INTO [enum].[UserRole] ([UserRoleId], [RoleName])
VALUES (1, N'Admin'),
(2, N'User')

-- SECURITY
INSERT INTO [security].[User] ([UserId], [FK_UserRoleId], [UserName]) 
VALUES (1, 1, N'Stephen'),
(2, 2, N'TestUser')

INSERT INTO [security].[NavMenu] ([NavMenuId], [NavMenuName], [NavMenuTitle], [NavMenuRoute]) 
VALUES (1, N'Home', N'Search Books And Comics', N'home'),
(2, N'Books', N'View Books', N'books'),
(3, N'Comics', N'View Comics', N'comics'),
(4, N'Admin', N'Only Admins Can See This', N'admin')

INSERT INTO [security].[NavMenuRole] ([NavMenuRoleId], [FK_NavMenuId], [FK_UserRoleId]) 
VALUES (1, 1, 1),
(2, 1, 2),
(3, 2, 1),
(4, 2, 2),
(5, 3, 1),
(6, 3, 2),
(7, 4, 1)