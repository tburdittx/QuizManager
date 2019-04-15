
-- =============================================
-- Author:		Tara Burditt
-- Create date: 29/03/2019
-- Description:	Updates questions
-- =============================================
CREATE PROCEDURE uspQuestionsUpdate 
	(
	@id		bigint,
	@categoryId BIGINT,
	@question nvarchar(526),
	@optionA	nvarchar(526),
	@optionB	nvarchar(526),
	@optionC	nvarchar(526),
	@optionD	nvarchar(526),
	@answer		nvarchar(526),
	@explanation nvarchar(526)
)

	As
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Questions]
   SET 
   [CategoryId]=@categoryId,
   [Question] = @question
      ,[OptionA] = @optionA
      ,[OptionB] = @optionB
      ,[OptionC] = @optionC
      ,[OptionD] = @optionD
      ,[Answer] = @answer
      ,[Explanation] = @explanation
 WHERE Id=@id
 END
GO
