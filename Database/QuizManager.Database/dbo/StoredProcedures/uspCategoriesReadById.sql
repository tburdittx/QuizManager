-- =============================================
-- Author:		Tara Burditt	
-- Create date: 31/03/2019
-- Description:	Reads categories by Id
-- =============================================
CREATE PROCEDURE uspCategoriesReadById
	@id bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [Id]
      ,[Name]
  FROM [dbo].[Categories]
  where Id=@id
END
GO
