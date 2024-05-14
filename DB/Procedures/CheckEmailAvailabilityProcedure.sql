USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[CheckEmailAvailability]    Script Date: 10/1/2023 12:40:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CheckEmailAvailability]
    @inputEmail NVARCHAR,
    @isAvailable BIT OUTPUT
AS
BEGIN
    SET @isAvailable = 0;

    IF NOT EXISTS (SELECT 1 FROM UserAcc WHERE email = @inputEmail)
    BEGIN
        SET @isAvailable = 1;
    END
END;
GO

