USE [ProjectManagementDb]
GO

/****** Object:  Table [dbo].[Task]    Script Date: 10/1/2023 12:29:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Task](
	[task_id] [int] IDENTITY(1,1) NOT NULL,
	[proj_id] [int] NULL,
	[task_name] [nvarchar](300) NOT NULL,
	[task_summary] [nvarchar](500) NULL,
	[task_details] [nvarchar](max) NULL,
	[assign_for_user_id] [int] NULL,
	[assign_by_user_id] [int] NULL,
	[task_notes] [nvarchar](max) NULL,
	[task_set_for_date] [date] NULL,
	[task_start_date] [date] NULL,
	[task_end_date] [date] NULL,
	[task_deadline] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[task_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [Assign_by_userId] FOREIGN KEY([assign_by_user_id])
REFERENCES [dbo].[UserAcc] ([user_id])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [Assign_by_userId]
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [Assign_for_userId] FOREIGN KEY([assign_for_user_id])
REFERENCES [dbo].[UserAcc] ([user_id])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [Assign_for_userId]
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [Proj_id] FOREIGN KEY([proj_id])
REFERENCES [dbo].[Project] ([proj_id])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [Proj_id]
GO

