-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE uspCategoriesUpdateById 
	-- Add the parameters for the stored procedure here
	@id bigint,
	@name nvarchar(526)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
UPDATE [dbo].[Categories]
   SET [Name] = @name
 WHERE Id=@id
END
GO
