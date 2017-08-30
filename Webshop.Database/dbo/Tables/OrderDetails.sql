CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailId] INT             IDENTITY (1, 1) NOT NULL,
    [OrderId]       INT             NOT NULL,
    [ProductId]     INT             NOT NULL,
    [Quantity]      DECIMAL (18, 2) NOT NULL,
    [SubTotal]      DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([OrderDetailId] ASC),
    CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([OrderId]),
    CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Order_Product]
    ON [dbo].[OrderDetails]([OrderId] ASC, [ProductId] ASC);

