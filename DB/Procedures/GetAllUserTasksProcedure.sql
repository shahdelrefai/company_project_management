USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetAllUserTasks]    Script Date: 10/1/2023 12:42:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUserTasks]
AS
BEGIN
    SELECT * FROM Task;
END;
GO

