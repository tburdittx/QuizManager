
CREATE TABLE [dbo].[Questions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryId] bigint not null,
	[Question] [nvarchar](526) NOT NULL,
	[OptionA] [nvarchar](526) NOT NULL,
	[OptionB] [nvarchar](526) NOT NULL,
	[OptionC] [nvarchar](526) NOT NULL,
	[OptionD] [nvarchar](526) NOT NULL,
	[Answer] [nvarchar](526) NOT NULL,
	[Explanation] [nvarchar](526) NOT NULL,
	[CreatedBy] [nvarchar](526) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](526) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
