
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/19/2019 19:01:26
-- Generated from EDMX file: C:\Users\andrew\source\repos\CarService\CarService\ModelService.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AUTO];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientAuto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autoturisme] DROP CONSTRAINT [FK_ClientAuto];
GO
IF OBJECT_ID(N'[dbo].[FK_SasiuAuto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autoturisme] DROP CONSTRAINT [FK_SasiuAuto];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientComanda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comenzi] DROP CONSTRAINT [FK_ClientComanda];
GO
IF OBJECT_ID(N'[dbo].[FK_AutoComanda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comenzi] DROP CONSTRAINT [FK_AutoComanda];
GO
IF OBJECT_ID(N'[dbo].[FK_ComandaDetaliuComanda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetaliiComenzi] DROP CONSTRAINT [FK_ComandaDetaliuComanda];
GO
IF OBJECT_ID(N'[dbo].[FK_MecanicDetaliuComanda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetaliiComenzi] DROP CONSTRAINT [FK_MecanicDetaliuComanda];
GO
IF OBJECT_ID(N'[dbo].[FK_MaterialDetaliuComanda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetaliiComenzi] DROP CONSTRAINT [FK_MaterialDetaliuComanda];
GO
IF OBJECT_ID(N'[dbo].[FK_OperatieDetaliuComanda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetaliiComenzi] DROP CONSTRAINT [FK_OperatieDetaliuComanda];
GO
IF OBJECT_ID(N'[dbo].[FK_ImagineDetaliuComanda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Imagini] DROP CONSTRAINT [FK_ImagineDetaliuComanda];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clienti]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clienti];
GO
IF OBJECT_ID(N'[dbo].[Autoturisme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autoturisme];
GO
IF OBJECT_ID(N'[dbo].[Sasiuri]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sasiuri];
GO
IF OBJECT_ID(N'[dbo].[Mecanici]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mecanici];
GO
IF OBJECT_ID(N'[dbo].[Materiale]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materiale];
GO
IF OBJECT_ID(N'[dbo].[Imagini]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Imagini];
GO
IF OBJECT_ID(N'[dbo].[Operatii]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operatii];
GO
IF OBJECT_ID(N'[dbo].[Comenzi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comenzi];
GO
IF OBJECT_ID(N'[dbo].[DetaliiComenzi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetaliiComenzi];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clienti'
CREATE TABLE [dbo].[Clienti] (
    [ClientId] int IDENTITY(1,1) NOT NULL,
    [Nume] nvarchar(15)  NOT NULL,
    [Prenume] nvarchar(15)  NOT NULL,
    [Adresa] nvarchar(50)  NOT NULL,
    [Localitate] nvarchar(10)  NOT NULL,
    [Judet] nvarchar(10)  NOT NULL,
    [Telefon] nvarchar(13)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Autoturisme'
CREATE TABLE [dbo].[Autoturisme] (
    [AutoId] int IDENTITY(1,1) NOT NULL,
    [NumarAuto] nvarchar(10)  NOT NULL,
    [SerieSasiu] nvarchar(25)  NOT NULL,
    [ClientClientId] int  NOT NULL,
    [SasiuSasiuId] int  NOT NULL
);
GO

-- Creating table 'Sasiuri'
CREATE TABLE [dbo].[Sasiuri] (
    [SasiuId] int IDENTITY(1,1) NOT NULL,
    [CodSasiu] nchar(2)  NOT NULL,
    [Denumire] nvarchar(25)  NOT NULL
);
GO

-- Creating table 'Mecanici'
CREATE TABLE [dbo].[Mecanici] (
    [MecanicId] int IDENTITY(1,1) NOT NULL,
    [Nume] nvarchar(15)  NOT NULL,
    [Prenume] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'Materiale'
CREATE TABLE [dbo].[Materiale] (
    [MaterialId] int IDENTITY(1,1) NOT NULL,
    [Denumire] nvarchar(50)  NOT NULL,
    [Cantitate] decimal(10,2)  NOT NULL,
    [Pret] decimal(10,2)  NOT NULL,
    [DataAprovizionare] datetime  NOT NULL
);
GO

-- Creating table 'Imagini'
CREATE TABLE [dbo].[Imagini] (
    [ImagineId] int IDENTITY(1,1) NOT NULL,
    [Titlu] nvarchar(15)  NOT NULL,
    [Descriere] nvarchar(256)  NOT NULL,
    [Data] datetime  NOT NULL,
    [Foto] varbinary(max)  NOT NULL,
    [DetaliuComanda_DetaliuComandaId] int  NOT NULL
);
GO

-- Creating table 'Operatii'
CREATE TABLE [dbo].[Operatii] (
    [OperatieId] int IDENTITY(1,1) NOT NULL,
    [Denumire] nvarchar(256)  NOT NULL,
    [TimpExecutie] decimal(6,2)  NOT NULL
);
GO

-- Creating table 'Comenzi'
CREATE TABLE [dbo].[Comenzi] (
    [ComandaId] int IDENTITY(1,1) NOT NULL,
    [StareComanda] nvarchar(25)  NOT NULL,
    [DataSystem] datetime  NOT NULL,
    [DataProgramare] datetime  NOT NULL,
    [DataFinalizare] datetime  NOT NULL,
    [KmBord] int  NOT NULL,
    [Descriere] nvarchar(1024)  NOT NULL,
    [ClientClientId] int  NOT NULL,
    [AutoAutoId] int  NOT NULL
);
GO

-- Creating table 'DetaliiComenzi'
CREATE TABLE [dbo].[DetaliiComenzi] (
    [DetaliuComandaId] int IDENTITY(1,1) NOT NULL,
    [ComandaComandaId] int  NOT NULL,
    [MecanicMecanicId] int  NOT NULL,
    [MaterialMaterialId] int  NOT NULL,
    [OperatieOperatieId] int  NOT NULL,
    [ImagineImagineId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ClientId] in table 'Clienti'
ALTER TABLE [dbo].[Clienti]
ADD CONSTRAINT [PK_Clienti]
    PRIMARY KEY CLUSTERED ([ClientId] ASC);
GO

-- Creating primary key on [AutoId] in table 'Autoturisme'
ALTER TABLE [dbo].[Autoturisme]
ADD CONSTRAINT [PK_Autoturisme]
    PRIMARY KEY CLUSTERED ([AutoId] ASC);
GO

-- Creating primary key on [SasiuId] in table 'Sasiuri'
ALTER TABLE [dbo].[Sasiuri]
ADD CONSTRAINT [PK_Sasiuri]
    PRIMARY KEY CLUSTERED ([SasiuId] ASC);
GO

-- Creating primary key on [MecanicId] in table 'Mecanici'
ALTER TABLE [dbo].[Mecanici]
ADD CONSTRAINT [PK_Mecanici]
    PRIMARY KEY CLUSTERED ([MecanicId] ASC);
GO

-- Creating primary key on [MaterialId] in table 'Materiale'
ALTER TABLE [dbo].[Materiale]
ADD CONSTRAINT [PK_Materiale]
    PRIMARY KEY CLUSTERED ([MaterialId] ASC);
GO

-- Creating primary key on [ImagineId] in table 'Imagini'
ALTER TABLE [dbo].[Imagini]
ADD CONSTRAINT [PK_Imagini]
    PRIMARY KEY CLUSTERED ([ImagineId] ASC);
GO

-- Creating primary key on [OperatieId] in table 'Operatii'
ALTER TABLE [dbo].[Operatii]
ADD CONSTRAINT [PK_Operatii]
    PRIMARY KEY CLUSTERED ([OperatieId] ASC);
GO

-- Creating primary key on [ComandaId] in table 'Comenzi'
ALTER TABLE [dbo].[Comenzi]
ADD CONSTRAINT [PK_Comenzi]
    PRIMARY KEY CLUSTERED ([ComandaId] ASC);
GO

-- Creating primary key on [DetaliuComandaId] in table 'DetaliiComenzi'
ALTER TABLE [dbo].[DetaliiComenzi]
ADD CONSTRAINT [PK_DetaliiComenzi]
    PRIMARY KEY CLUSTERED ([DetaliuComandaId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientClientId] in table 'Autoturisme'
ALTER TABLE [dbo].[Autoturisme]
ADD CONSTRAINT [FK_ClientAuto]
    FOREIGN KEY ([ClientClientId])
    REFERENCES [dbo].[Clienti]
        ([ClientId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientAuto'
CREATE INDEX [IX_FK_ClientAuto]
ON [dbo].[Autoturisme]
    ([ClientClientId]);
GO

-- Creating foreign key on [SasiuSasiuId] in table 'Autoturisme'
ALTER TABLE [dbo].[Autoturisme]
ADD CONSTRAINT [FK_SasiuAuto]
    FOREIGN KEY ([SasiuSasiuId])
    REFERENCES [dbo].[Sasiuri]
        ([SasiuId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SasiuAuto'
CREATE INDEX [IX_FK_SasiuAuto]
ON [dbo].[Autoturisme]
    ([SasiuSasiuId]);
GO

-- Creating foreign key on [ClientClientId] in table 'Comenzi'
ALTER TABLE [dbo].[Comenzi]
ADD CONSTRAINT [FK_ClientComanda]
    FOREIGN KEY ([ClientClientId])
    REFERENCES [dbo].[Clienti]
        ([ClientId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientComanda'
CREATE INDEX [IX_FK_ClientComanda]
ON [dbo].[Comenzi]
    ([ClientClientId]);
GO

-- Creating foreign key on [AutoAutoId] in table 'Comenzi'
ALTER TABLE [dbo].[Comenzi]
ADD CONSTRAINT [FK_AutoComanda]
    FOREIGN KEY ([AutoAutoId])
    REFERENCES [dbo].[Autoturisme]
        ([AutoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutoComanda'
CREATE INDEX [IX_FK_AutoComanda]
ON [dbo].[Comenzi]
    ([AutoAutoId]);
GO

-- Creating foreign key on [ComandaComandaId] in table 'DetaliiComenzi'
ALTER TABLE [dbo].[DetaliiComenzi]
ADD CONSTRAINT [FK_ComandaDetaliuComanda]
    FOREIGN KEY ([ComandaComandaId])
    REFERENCES [dbo].[Comenzi]
        ([ComandaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComandaDetaliuComanda'
CREATE INDEX [IX_FK_ComandaDetaliuComanda]
ON [dbo].[DetaliiComenzi]
    ([ComandaComandaId]);
GO

-- Creating foreign key on [MecanicMecanicId] in table 'DetaliiComenzi'
ALTER TABLE [dbo].[DetaliiComenzi]
ADD CONSTRAINT [FK_MecanicDetaliuComanda]
    FOREIGN KEY ([MecanicMecanicId])
    REFERENCES [dbo].[Mecanici]
        ([MecanicId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MecanicDetaliuComanda'
CREATE INDEX [IX_FK_MecanicDetaliuComanda]
ON [dbo].[DetaliiComenzi]
    ([MecanicMecanicId]);
GO

-- Creating foreign key on [MaterialMaterialId] in table 'DetaliiComenzi'
ALTER TABLE [dbo].[DetaliiComenzi]
ADD CONSTRAINT [FK_MaterialDetaliuComanda]
    FOREIGN KEY ([MaterialMaterialId])
    REFERENCES [dbo].[Materiale]
        ([MaterialId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaterialDetaliuComanda'
CREATE INDEX [IX_FK_MaterialDetaliuComanda]
ON [dbo].[DetaliiComenzi]
    ([MaterialMaterialId]);
GO

-- Creating foreign key on [OperatieOperatieId] in table 'DetaliiComenzi'
ALTER TABLE [dbo].[DetaliiComenzi]
ADD CONSTRAINT [FK_OperatieDetaliuComanda]
    FOREIGN KEY ([OperatieOperatieId])
    REFERENCES [dbo].[Operatii]
        ([OperatieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperatieDetaliuComanda'
CREATE INDEX [IX_FK_OperatieDetaliuComanda]
ON [dbo].[DetaliiComenzi]
    ([OperatieOperatieId]);
GO

-- Creating foreign key on [DetaliuComanda_DetaliuComandaId] in table 'Imagini'
ALTER TABLE [dbo].[Imagini]
ADD CONSTRAINT [FK_ImagineDetaliuComanda]
    FOREIGN KEY ([DetaliuComanda_DetaliuComandaId])
    REFERENCES [dbo].[DetaliiComenzi]
        ([DetaliuComandaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImagineDetaliuComanda'
CREATE INDEX [IX_FK_ImagineDetaliuComanda]
ON [dbo].[Imagini]
    ([DetaliuComanda_DetaliuComandaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------