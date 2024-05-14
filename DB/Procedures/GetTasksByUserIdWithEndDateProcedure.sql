USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetTasksByUserIdWithEndDate]    Script Date: 10/1/2023 12:46:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTasksByUserIdWithEndDate]
    @userId INT
AS
BEGIN
    SELECT task_id
    FROM [dbo].[Task]
    WHERE assign_for_user_id = @userId
    AND task_end_date IS NOT NULL;
END;
GO

