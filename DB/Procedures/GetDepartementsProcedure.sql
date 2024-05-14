USE [ProjectManagementDb]
GO

/****** Object:  StoredProcedure [dbo].[GetDepartements]    Script Date: 10/1/2023 12:43:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetDepartements]
AS
BEGIN
	SELECT dep_name, dep_id FROM Departement;
END;
GO

