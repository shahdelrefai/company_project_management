USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[AddProject]    Script Date: 10/1/2023 12:39:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddProject]
	@name NVARCHAR(300),
	@createdBy INT,
	@startDate DATETIME,
	@deadline DATETIME,
	@summary NVARCHAR(500),
	@details NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO Project(proj_name, created_by_id, proj_start_date, proj_deadline, proj_summary, proj_details)
	VALUES (@name, @createdBy, @startDate, @deadline, @summary, @details)
END;
GO

