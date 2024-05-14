USE [ProjectManagementDb]
GO

/****** Object:  Table [dbo].[Team]    Script Date: 10/1/2023 12:29:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Team](
	[team_id] [int] IDENTITY(1,1) NOT NULL,
	[team_manager_id] [int] NULL,
	[team_leader_id] [int] NULL,
	[dep_id] [int] NULL,
	[team_name] [nvarchar](255) NULL,
	[proj_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[team_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [Dep_id] FOREIGN KEY([dep_id])
REFERENCES [dbo].[Departement] ([dep_id])
GO

ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [Dep_id]
GO

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [team_projid] FOREIGN KEY([proj_id])
REFERENCES [dbo].[Project] ([proj_id])
GO

ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [team_projid]
GO

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [TeamLeader] FOREIGN KEY([team_leader_id])
REFERENCES [dbo].[UserAcc] ([user_id])
GO

ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [TeamLeader]
GO

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [TeamManager] FOREIGN KEY([team_manager_id])
REFERENCES [dbo].[UserAcc] ([user_id])
GO

ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [TeamManager]
GO

