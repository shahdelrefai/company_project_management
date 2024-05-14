USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[ReturnIfUsernameFound]    Script Date: 10/1/2023 12:47:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReturnIfUsernameFound]
    @inputUsername NVARCHAR(50)
AS
BEGIN

    SELECT * FROM UserAcc WHERE username = @inputUsername;
   
END;
GO

