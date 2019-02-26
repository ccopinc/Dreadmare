
CREATE TABLE [dbo].[movie_Review](
	[id_Review] [int] IDENTITY(1,1) NOT NULL,
	[IMDB_ID] [nvarchar](50) NULL,
	[id_Reviewer] [int] NOT NULL,
	[MovieTitle] [nvarchar](100) NOT NULL,
	[ReviewTitle] [nvarchar](100) NULL,
	[Review] [nvarchar](1000) NOT NULL,
	[OverAllPoints] [int] NOT NULL,
	[ScriptPoints] [int] NOT NULL,
	[ActingPoints] [int] NOT NULL,
	[EffectsPoints] [int] NOT NULL,
	[SoundPoints] [int] NOT NULL,
	[ReviewDate] [datetime] NULL,
	[TotalScore] [int] NOT NULL,
 CONSTRAINT [PK_movie_Review] PRIMARY KEY CLUSTERED 
(
	[id_Review] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO