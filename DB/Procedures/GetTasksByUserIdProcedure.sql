USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetTasksByUserId]    Script Date: 10/1/2023 12:44:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTasksByUserId]
    @userId INT
AS
BEGIN
    SELECT task_id, proj_id, task_name, assign_by_user_id, task_set_for_date, task_start_date, task_end_date, task_deadline, task_details, task_summary, task_notes
    FROM [dbo].[Task]
    WHERE assign_for_user_id = @userId AND task_end_date IS NULL
	ORDER BY task_set_for_date;
END;
GO

