
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/16/2013 00:59:02
-- Generated from EDMX file: C:\Users\Smith\Google Drive\HealthStreamMvcApplication\HealthStreamMvcApplication\Models\PersonModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SimpleContactDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AddressPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_AddressPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressAddressType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_AddressAddressType];
GO
IF OBJECT_ID(N'[dbo].[FK_PhonePerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Phones] DROP CONSTRAINT [FK_PhonePerson];
GO
IF OBJECT_ID(N'[dbo].[FK_PhonePhoneType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Phones] DROP CONSTRAINT [FK_PhonePhoneType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Phones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phones];
GO
IF OBJECT_ID(N'[dbo].[PhoneTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhoneTypes];
GO
IF OBJECT_ID(N'[dbo].[AddressTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AddressTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [PersonID] int IDENTITY(1,1) NOT NULL,
    [First] nvarchar(max)  NOT NULL,
    [Last] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressID] int IDENTITY(1,1) NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Zip] nvarchar(max)  NOT NULL,
    [PersonID] int  NOT NULL,
    [AddressTypeID] int  NOT NULL,
    [People_PersonID] int  NOT NULL,
    [AddressTypes_AddressTypeID] int  NOT NULL
);
GO

-- Creating table 'Phones'
CREATE TABLE [dbo].[Phones] (
    [PhoneID] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [PersonID] int  NOT NULL,
    [PhoneTypeID] int  NOT NULL,
    [People_PersonID] int  NOT NULL,
    [PhoneTypes_PhoneTypeID] int  NOT NULL
);
GO

-- Creating table 'PhoneTypes'
CREATE TABLE [dbo].[PhoneTypes] (
    [PhoneTypeID] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AddressTypes'
CREATE TABLE [dbo].[AddressTypes] (
    [AddressTypeID] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PersonID] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([PersonID] ASC);
GO

-- Creating primary key on [AddressID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressID] ASC);
GO

-- Creating primary key on [PhoneID] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [PK_Phones]
    PRIMARY KEY CLUSTERED ([PhoneID] ASC);
GO

-- Creating primary key on [PhoneTypeID] in table 'PhoneTypes'
ALTER TABLE [dbo].[PhoneTypes]
ADD CONSTRAINT [PK_PhoneTypes]
    PRIMARY KEY CLUSTERED ([PhoneTypeID] ASC);
GO

-- Creating primary key on [AddressTypeID] in table 'AddressTypes'
ALTER TABLE [dbo].[AddressTypes]
ADD CONSTRAINT [PK_AddressTypes]
    PRIMARY KEY CLUSTERED ([AddressTypeID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [People_PersonID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_AddressPerson]
    FOREIGN KEY ([People_PersonID])
    REFERENCES [dbo].[People]
        ([PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressPerson'
CREATE INDEX [IX_FK_AddressPerson]
ON [dbo].[Addresses]
    ([People_PersonID]);
GO

-- Creating foreign key on [AddressTypes_AddressTypeID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_AddressAddressType]
    FOREIGN KEY ([AddressTypes_AddressTypeID])
    REFERENCES [dbo].[AddressTypes]
        ([AddressTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressAddressType'
CREATE INDEX [IX_FK_AddressAddressType]
ON [dbo].[Addresses]
    ([AddressTypes_AddressTypeID]);
GO

-- Creating foreign key on [People_PersonID] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [FK_PhonePerson]
    FOREIGN KEY ([People_PersonID])
    REFERENCES [dbo].[People]
        ([PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PhonePerson'
CREATE INDEX [IX_FK_PhonePerson]
ON [dbo].[Phones]
    ([People_PersonID]);
GO

-- Creating foreign key on [PhoneTypes_PhoneTypeID] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [FK_PhonePhoneType]
    FOREIGN KEY ([PhoneTypes_PhoneTypeID])
    REFERENCES [dbo].[PhoneTypes]
        ([PhoneTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PhonePhoneType'
CREATE INDEX [IX_FK_PhonePhoneType]
ON [dbo].[Phones]
    ([PhoneTypes_PhoneTypeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------