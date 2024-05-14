USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetTasksByUserIdOrderedByStartDate]    Script Date: 10/1/2023 12:45:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTasksByUserIdOrderedByStartDate]
    @userId INT
AS
BEGIN
    SELECT task_id
    FROM [dbo].[Task]
    WHERE assign_for_user_id = @userId
    ORDER BY task_start_date ASC;
END;
GO

