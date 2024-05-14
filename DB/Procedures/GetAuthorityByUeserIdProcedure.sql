USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetAuthorityeByUeserId]    Script Date: 10/1/2023 12:42:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAuthorityeByUeserId]
    @userId INT
AS
BEGIN
    SELECT Authority FROM UserAcc WHERE user_id = @userId;
END;
GO

