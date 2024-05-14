USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[AddUserAcc]    Script Date: 10/1/2023 12:40:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUserAcc]
	@username NVARCHAR(50),
	@password NVARCHAR(MAX),
	@email NVARCHAR(255),
	@fullName NVARCHAR(255)
AS
BEGIN
	INSERT INTO UserAcc(username, password, email, full_name, access, account_type, Authority)
	VALUES(@username, @password, @email, @fullName, 0, 'user', 0);
END;
GO

