CREATE TABLE [dbo].[Orders] (
    [OrderId]      INT             IDENTITY (1, 1) NOT NULL,
    [CustomerId]   INT             NOT NULL,
    [Total]        DECIMAL (18, 2) CONSTRAINT [DF_Orders_Total] DEFAULT ((0)) NOT NULL,
    [CreationDate] DATETIME2 (7)   CONSTRAINT [DF_Orders_CreationDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);

