USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetAccountTypeByUeserId]    Script Date: 10/1/2023 12:41:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAccountTypeByUeserId]
    @userId INT
AS
BEGIN
    SELECT account_type FROM UserAcc WHERE user_id = @userId;
END;
GO

