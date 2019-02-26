-- AS OF 2/26/19

USE [dm_db]
GO
SET IDENTITY_INSERT [dbo].[core_User] ON 
GO
INSERT [dbo].[core_User] ([id_User], [Pwd], [FirstName], [LastName], [Email], [FaceBook], [Instagram], [Twitter], [SnapChat], [SecLevel]) VALUES (2, N'xxx', N'Craig', N'Coppola', N'ccopinc@aol.com', NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[core_User] OFF
GO
SET IDENTITY_INSERT [dbo].[movie_Review] ON 
GO
INSERT [dbo].[movie_Review] ([id_Review], [IMDB_ID], [id_Reviewer], [MovieTitle], [ReviewTitle], [Review], [OverAllPoints], [ScriptPoints], [ActingPoints], [EffectsPoints], [SoundPoints], [ReviewDate], [TotalScore]) VALUES (1, N'1234', 1, N'Hellraiser', N'The greatest horror movie ever.', N'I think Hellraiser is the greatest horror movie ever.  It is my fave.', 10, 10, 10, 10, 10, CAST(N'2019-02-21T00:00:00.000' AS DateTime), 10)
GO
SET IDENTITY_INSERT [dbo].[movie_Review] OFF
GO
SET IDENTITY_INSERT [dbo].[quote_Quote] ON 
GO
INSERT [dbo].[quote_Quote] ([id_Quote], [Quote], [QuoteBy], [QuoteByImage]) VALUES (1, N'Save your tears. I’ll reap your sorrow slowly. I have centuries to discover the things that make you whimper.', N'Hellraiser - Lead Cenobite', N'images/quotes/hellraiser_lead_cenobite.png')
GO
INSERT [dbo].[quote_Quote] ([id_Quote], [Quote], [QuoteBy], [QuoteByImage]) VALUES (3, N'You solved the box, we came. Now you must come with us, taste our pleasures.', N'Hellraiser - Lead Cenobite', N'images/quotes/hellraiser_lead_cenobite.png')
GO
INSERT [dbo].[quote_Quote] ([id_Quote], [Quote], [QuoteBy], [QuoteByImage]) VALUES (4, N'Hope not ever to see Heaven. I have come to lead you to the other shore; into eternal darkness; into fire and into ice.', N'Inferno- Dante Alighieri', N'images/quotes/Dante_Inferno.png')
GO
INSERT [dbo].[quote_Quote] ([id_Quote], [Quote], [QuoteBy], [QuoteByImage]) VALUES (5, N'Listen to them, the children of the night. What music they make!', N'Dracula - Brahm Stoker', N'images/quotes/Dracula_Bram_Stoker.png')
GO
SET IDENTITY_INSERT [dbo].[quote_Quote] OFF
GO
