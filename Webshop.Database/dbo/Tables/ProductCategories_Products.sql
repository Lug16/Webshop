CREATE TABLE [dbo].[ProductCategories_Products] (
    [ProductCategoryId] INT NOT NULL,
    [ProductId]         INT NOT NULL,
    CONSTRAINT [PK_ProductCategories_Products] PRIMARY KEY CLUSTERED ([ProductCategoryId] ASC, [ProductId] ASC),
    CONSTRAINT [FK_ProductCategories_Products_ProductCategories] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategories] ([ProductCategoryId]),
    CONSTRAINT [FK_ProductCategories_Products_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);

