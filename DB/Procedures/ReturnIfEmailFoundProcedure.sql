USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[ReturnIfEmailFound]    Script Date: 10/1/2023 12:47:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReturnIfEmailFound]
    @inputEmail NVARCHAR(255)
AS
BEGIN

    SELECT * FROM UserAcc WHERE email = @inputEmail;
   
END;
GO

