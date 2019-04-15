-- =============================================
-- Author:		Tara Burditt
-- Create date: 29/03/2019
-- Description:	Deletes questions by Id
-- =============================================
CREATE PROCEDURE uspQuestionsDelete
 
	@id	bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DELETE FROM [dbo].[Questions]
      WHERE Id=@id
END
GO
