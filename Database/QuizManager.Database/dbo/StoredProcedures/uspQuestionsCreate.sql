-- =============================================
-- Author:		Tara Burditt
-- Create date: 3/29/2019
-- Description:	Creates a new question
-- =============================================
CREATE PROCEDURE uspQuestionsCreate
	(
	@categoryId	BIGINT,
	@question nvarchar(526),
	@optionA	nvarchar(526),
	@optionB	nvarchar(526),
	@optionC	nvarchar(526),
	@optionD	nvarchar(526),
	@answer		nvarchar(526),
	@explanation nvarchar(526)
	)

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Questions]
           ([CategoryId]
		   ,[Question]
           ,[OptionA]
           ,[OptionB]
           ,[OptionC]
           ,[OptionD]
           ,[Answer]
           ,[Explanation])
     VALUES
	 (@categoryId,
           @question ,
	@optionA	,
	@optionB	,
	@optionC	,
	@optionD	,
	@answer		,
	@explanation
	)
END
GO
