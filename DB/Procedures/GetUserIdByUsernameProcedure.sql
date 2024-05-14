USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetUserIdByUsername]    Script Date: 10/1/2023 12:47:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserIdByUsername]
    @username NVARCHAR(50)
AS
BEGIN

    SELECT user_id FROM UserAcc WHERE username = @username;
   
END;
GO

