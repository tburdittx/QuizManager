-- =============================================
-- Author:		Tara Burditt
-- Create date: 31/03/2019
-- Description:	Deletes categories by Id
-- =============================================
CREATE PROCEDURE uspCategoriesDeleteById
	@id bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[Categories]
      WHERE ID=@id
END
GO
