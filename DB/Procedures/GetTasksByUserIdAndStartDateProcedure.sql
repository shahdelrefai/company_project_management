USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetTasksByUserIdAndStartDate]    Script Date: 10/1/2023 12:45:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTasksByUserIdAndStartDate]
    @userId INT,
    @startDate DATE
AS
BEGIN
    SELECT task_id
    FROM [dbo].[Task]
    WHERE assign_for_user_id = @userId
    AND task_start_date = @startDate;
END;
GO

