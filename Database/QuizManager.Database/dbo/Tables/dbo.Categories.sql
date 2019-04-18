CREATE TABLE [dbo].[Categories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](526) NOT NULL,
	[Description] [nvarchar](526) NOT NULL,
	[CreatedBy] [nvarchar](526) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](526) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL
) ON [PRIMARY]
