
CREATE TABLE [dbo].[quote_Quote](
	[id_Quote] [int] IDENTITY(1,1) NOT NULL,
	[Quote] [nvarchar](300) NOT NULL,
	[QuoteBy] [nvarchar](100) NOT NULL,
	[QuoteByImage] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_quote_Quote] PRIMARY KEY CLUSTERED 
(
	[id_Quote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[quote_Quote] ADD  DEFAULT ('') FOR [QuoteByImage]
GO