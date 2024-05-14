USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetTasksByUserIdWithPastDeadline]    Script Date: 10/1/2023 12:46:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTasksByUserIdWithPastDeadline]
    @userId INT
AS
BEGIN
    SELECT task_id
    FROM [dbo].[Task]
    WHERE assign_for_user_id = @userId
    AND task_deadline < GETDATE();
END;
GO

