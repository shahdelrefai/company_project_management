USE [ProjectManagementDb]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 10/1/2023 12:29:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project](
	[proj_id] [int] IDENTITY(1,1) NOT NULL,
	[proj_name] [nvarchar](300) NOT NULL,
	[proj_summary] [nvarchar](500) NULL,
	[proj_start_date] [datetime] NULL,
	[proj_end_date] [datetime] NULL,
	[proj_deadline] [datetime] NULL,
	[created_by_id] [int] NULL,
	[proj_details] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[proj_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[proj_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [ProjCreatedBy] FOREIGN KEY([created_by_id])
REFERENCES [dbo].[UserAcc] ([user_id])
GO

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [ProjCreatedBy]
GO

