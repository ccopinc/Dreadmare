
CREATE TABLE [dbo].[writing_Writing](
	[id_Writing] [int] IDENTITY(1,1) NOT NULL,
	[WritingType] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Author] [int] NOT NULL,
	[WritingUrl] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_writing_Writing] PRIMARY KEY CLUSTERED 
(
	[id_Writing] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO