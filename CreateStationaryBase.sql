USE master

CREATE DATABASE StationaryStore

USE StationaryStore

CREATE TABLE [dbo].[Product] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX) NOT NULL,
    [Type]  INT            NOT NULL,
    [Price] FLOAT (53)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Type]) REFERENCES [dbo].[ProductType] ([Id])
);

CREATE TABLE [dbo].[Managers] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ProductType] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Type]     NVARCHAR (MAX) NOT NULL,
    [Quantity] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Sale] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [ManagerId]       INT            NOT NULL,
    [ProductId]       INT            NOT NULL,
    [ProductQuantity] INT            NOT NULL,
    [BuyerCompany]    NVARCHAR (MAX) NOT NULL,
    [Date]            DATE           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    FOREIGN KEY ([ManagerId]) REFERENCES [dbo].[Managers] ([Id])
);

