USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetNameByUsername]    Script Date: 10/1/2023 12:44:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetNameByUsername]
    @username NVARCHAR(50)
AS
BEGIN

    SELECT full_name FROM UserAcc WHERE username = @username;
   
END;
GO

