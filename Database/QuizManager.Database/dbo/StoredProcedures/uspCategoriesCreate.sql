-- =============================================
-- Author:		Tara Burditt
-- Create date: 31/03/2019
-- Description:	Create new categories
-- =============================================
CREATE PROCEDURE uspCategoriesCreate

@name	nvarchar(526),
@description nvarchar(526)

AS
BEGIN
INSERT INTO [dbo].[Categories]
           ([Name],
		   [Description])
     VALUES
           (
		   @name,
		   @description
		   )

END
GO
