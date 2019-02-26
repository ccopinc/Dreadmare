
CREATE TABLE [dbo].[movie_News](
	[id_MovieNews] [int] IDENTITY(1,1) NOT NULL,
	[IMDB_ID] [nvarchar](50) NOT NULL,
	[MovieTitle] [nvarchar](100) NULL,
	[News] [nvarchar](max) NULL,
	[NewsDate] [datetime] NULL,
	[NewsBy] [int] NULL,
 CONSTRAINT [PK_movie_News] PRIMARY KEY CLUSTERED 
(
	[id_MovieNews] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO