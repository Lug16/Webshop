CREATE TABLE [dbo].[Products] (
    [ProductId]    INT             IDENTITY (1, 1) NOT NULL,
    [Number]       NVARCHAR (10)   NOT NULL,
    [Name]         NVARCHAR (200)  NOT NULL,
    [Price]        DECIMAL (18, 2) NOT NULL,
    [CreationDate] DATETIME2 (7)   CONSTRAINT [DF_Products_CreationDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);





