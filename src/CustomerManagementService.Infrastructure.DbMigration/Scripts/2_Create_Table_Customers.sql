USE CustomerManagementService;
GO

IF OBJECT_ID(N'dbo.Customers', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Customers
	(
		[Id] INT NOT NULL,
		[Age] INT NOT NULL,
		[FirstName] nvarchar(50) NOT NULL,
		[LastName] nvarchar(50) NOT NULL,
		CONSTRAINT [PK_Customers_Id] PRIMARY KEY ([Id])
	);
END