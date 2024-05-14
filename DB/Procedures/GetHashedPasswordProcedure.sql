USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetHashedPassword]    Script Date: 10/1/2023 12:43:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetHashedPassword]
    @username NVARCHAR(50)
AS
BEGIN

    SELECT password FROM UserAcc WHERE username = @username;
   
END;
GO

