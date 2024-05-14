USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 10/1/2023 12:41:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
    SELECT * FROM UserAcc;
END;
GO

