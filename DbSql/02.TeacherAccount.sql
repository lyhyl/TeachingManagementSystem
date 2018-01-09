USE [TMS]
GO

/****** Object:  Table [dbo].[TeacherAccount]    Script Date: 1/9/2018 23:17:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TeacherAccount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[brand] [nvarchar](50) NOT NULL,
	[sex] [int] NOT NULL,
	[phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_TeacherAccount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

