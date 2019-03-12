
CREATE TABLE [dbo].[core_User](
	[id_User] [int] IDENTITY(1,1) NOT NULL,
	[Pwd] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[FaceBook] [nvarchar](100) NULL,
	[Instagram] [nvarchar](100) NULL,
	[Twitter] [nvarchar](100) NULL,
	[SnapChat] [nvarchar](100) NULL,
	[SecLevel] [int] NOT NULL,
 [UserName] NVARCHAR(20) NULL, 
    CONSTRAINT [PK_core_User] PRIMARY KEY CLUSTERED 
(
	[id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO