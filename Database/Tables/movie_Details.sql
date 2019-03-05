
CREATE TABLE [dbo].[movie_Details](
	[Title] [nvarchar](100) NOT NULL,
	[Year] [int] NULL,
	[Rated] [nvarchar](10) NULL,
	[Released] [nvarchar](50) NULL,
	[Runtime] [nchar](10) NULL,
	[Genre] [nvarchar](50) NULL,
	[Director] [nvarchar](100) NULL,
	[Writer] [nvarchar](100) NULL,
	[Actors] [nvarchar](1000) NULL,
	[Plot] [nvarchar](max) NULL,
	[Language] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Awards] [nvarchar](50) NULL,
	[Poster] [nvarchar](250) NULL,
	[Ratings] [nvarchar](500) NULL,
	[Metascore] [nvarchar](50) NULL,
	[IMDBRating] [nvarchar](10) NULL,
	[IMDBVotes] [nvarchar](15) NULL,
	[IMDBID] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NULL,
	[DVD] [nvarchar](50) NULL,
	[BoxOffice] [nvarchar](50) NULL,
	[Production] [nvarchar](100) NULL,
	[Website] [nvarchar](100) NULL,
	[Response] [nchar](10) NULL,
 CONSTRAINT [PK_movie_Details] PRIMARY KEY CLUSTERED 
(
	[IMDBID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


