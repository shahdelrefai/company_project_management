USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[AddTeam]    Script Date: 10/1/2023 12:40:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddTeam]
	@name NVARCHAR(255),
	@depId INT
AS
BEGIN
	INSERT INTO Team(team_name, dep_id)
	VALUES (@name, @depId);
END;
GO

