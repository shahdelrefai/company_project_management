USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[AddDepartement]    Script Date: 10/1/2023 12:39:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddDepartement]
	@name NVARCHAR(100),
	@depHeadId NVARCHAR
AS
BEGIN
	INSERT INTO Departement(dep_name, dep_head_id)
	VALUES (@name, @depHeadId);
END;
GO

