USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[AddTask]    Script Date: 10/1/2023 12:39:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddTask]
	@projId INT = NULL,
	@name NVARCHAR(300),
    @assignFor INT,
	@assignBy INT,
	@setForDate Date,
	@deadline Date = NULL,
	@summary NVARCHAR(500) = NULL,
	@details NVARCHAR(MAX) =NULL
AS
BEGIN
	INSERT INTO Task(proj_id, task_name, assign_by_user_id, assign_for_user_id, task_set_for_date, task_start_date, task_deadline, task_summary, task_details)
	VALUES (@projId, @name, @assignFor, @assignBy, @setForDate, @setForDate, @deadline, @summary, @details)
END;
GO

