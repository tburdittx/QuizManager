-- =============================================
-- Author:		Tara Burditt
-- Create date: 31/03/2019
-- Description:	Create new categories
-- =============================================
CREATE PROCEDURE uspCategoriesCreate


@name	nvarchar(526),
@description nvarchar(526),
@createdBy nvarchar(526),
@createdDate datetime2(7),
@modifiedBy nvarchar(526),
@modifiedDate datetime2(7)

AS
BEGIN
INSERT INTO [dbo].[Categories]
           ([Name],
		   [Description],
		   [CreatedBy],
		   [CreatedDate],
		   [ModifiedBy],
		   [ModifiedDate])
     VALUES
           (
		   @name,
		   @description,
		   @createdBy,
		   @createdDate,
		   @modifiedBy,
		   @modifiedDate
		   )

END
GO
