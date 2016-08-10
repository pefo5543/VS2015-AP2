
SET IDENTITY_INSERT [Items] ON
INSERT INTO [Items] ([ItemId], [Type], [Name], [Description]) VALUES (2, N'Weapon', N'Standard dagger', N'A common dagger')
SET IDENTITY_INSERT [Items] OFF

SET IDENTITY_INSERT [Weapons] ON
INSERT INTO [Weapons] ([ItemId], [WeaponType], [Damage], [ExtraDamage]) VALUES (2, N'Dagger', 4, 0)
SET IDENTITY_INSERT [Weapons] OFF