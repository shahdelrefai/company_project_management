USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[SearchUsersByUsername]    Script Date: 10/1/2023 12:48:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchUsersByUsername]
    @PartialUsername NVARCHAR
AS
BEGIN
    SELECT TOP 5 user_id, username
    FROM UserAcc
    WHERE username LIKE @PartialUsername + '%'
    ORDER BY username;
END;
GO

