-- =============================================
-- Author:		Tara Burditt
-- Create date: 3/29/2019
-- Description:	Reads all questions 
-- =============================================
CREATE PROCEDURE uspQuestionsReadAll

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

END
GO