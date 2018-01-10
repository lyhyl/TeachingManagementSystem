USE [TMS]
GO

/****** Object:  Table [dbo].[Class]    Script Date: 1/10/2018 16:16:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[tid] [int] NOT NULL,
	[category] [nvarchar](50) NOT NULL,
	[time] [nvarchar](50) NOT NULL,
	[place] [nvarchar](50) NOT NULL,
	[capability] [int] NOT NULL,
	[usualProportion] [float] NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_TeacherAccount] FOREIGN KEY([tid])
REFERENCES [dbo].[TeacherAccount] ([id])
GO

ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_TeacherAccount]
GO

