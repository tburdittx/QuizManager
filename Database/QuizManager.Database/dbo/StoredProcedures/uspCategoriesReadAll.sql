-- =============================================
-- Author:		Tara Burditt
-- Create date: 31/03/2019
-- Description:	Reads all categories
-- =============================================
CREATE PROCEDURE uspCategoriesReadAll

AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id]
      ,[Name]
  FROM [dbo].[Categories]
  end
GO

