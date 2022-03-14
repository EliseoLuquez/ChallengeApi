use ChallengeTotvsDb
GO

create table Transactions(
	[Id] UNIQUEIDENTIFIER not null,
	[AmountPaid] DECIMAL(18,2),
	[TotalCost] DECIMAL(18,2),
	[Change] DECIMAL(18,2),
	[MessageChange] NVARCHAR(512),
	[DateCreate] DATETIME,

	CONSTRAINT PK_Transaccion PRIMARY KEY (Id)
);
GO 