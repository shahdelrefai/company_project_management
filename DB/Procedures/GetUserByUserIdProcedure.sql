USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetUserByUserId]    Script Date: 10/1/2023 12:47:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByUserId]
	@userId INT
AS
BEGIN
    SELECT * FROM UserAcc WHERE user_id = @userId;
END;
GO

