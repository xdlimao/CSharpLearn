create database TesteDatabase

use TesteDatabase

USE [TesteDatabase]
GO

SELECT [Id]
      ,[Title]
      ,[Genre]
      ,[ReleaseDate]
  FROM [dbo].[Movies]

GO

USE [TesteDatabase]
GO

INSERT INTO [dbo].[Movies]
           ([Title]
           ,[Genre]
           ,[ReleaseDate])
     VALUES
           ('Peralta',
		   'Teror', GETDATE())
GO

