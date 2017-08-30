CREATE TABLE [dbo].[ProductCategories] (
    [ProductCategoryId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (50) NOT NULL,
    [CreationDate]      DATETIME2 (7) CONSTRAINT [DF_ProductCategories_CreationDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED ([ProductCategoryId] ASC)
);

