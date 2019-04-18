-- =============================================
-- Author:		Tara Burditt
-- Create date: 15/04/2019
-- Description:	Updates categories by Id
-- =============================================
CREATE PROCEDURE uspCategoriesUpdateById 
	-- Add the parameters for the stored procedure here
	@id bigint,
@name	nvarchar(526),
@description nvarchar(526),
@modifiedBy nvarchar(526),
@modifiedDate datetime2(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
UPDATE [dbo].[Categories]
   SET [Name] = @name,
   [Description]=@description,
   [ModifiedBy]=@modifiedBy,
   [ModifiedDate]=@modifiedDate
 WHERE Id=@id
END