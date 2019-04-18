-- =============================================
-- Author:		Tara Burditt
-- Create date: 3/29/2019
-- Description:	Reads questions by Id
-- =============================================
CREATE PROCEDURE uspQuestionsReadById
	@id bigint
AS
BEGIN
	SET NOCOUNT ON;
SELECT [Id]
,[CategoryId]
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
	  ,[ModifiedDate] 
  FROM [QuizManager].[dbo].[Questions]
  where Id=@id

END
GO