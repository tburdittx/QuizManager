-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE uspQuestionsReadByCategoryId
	-- Add the parameters for the stored procedure here
(@categoryId bigint)
as
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [Id]
      ,[CategoryId]
      ,[Question]
      ,[OptionA]
      ,[OptionB]
      ,[OptionC]
      ,[OptionD]
      ,[Answer]
      ,[Explanation]
  FROM [dbo].[Questions]
  where CategoryId=@categoryId
END
GO
