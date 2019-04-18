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
	@explanation nvarchar(526),
	@createdBy nvarchar(526),
@createdDate datetime2(7),
@modifiedBy nvarchar(526),
@modifiedDate datetime2(7)
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
           ,[Explanation]
		   ,[CreatedBy]
		   ,[CreatedDate]
		   ,[ModifiedBy]
		   ,[ModifiedDate])
     VALUES
	 (@categoryId,
           @question ,
	@optionA	,
	@optionB	,
	@optionC	,
	@optionD	,
	@answer		,
	@explanation,
	 @createdBy,
		   @createdDate,
		   @modifiedBy,
		   @modifiedDate
	)
END
