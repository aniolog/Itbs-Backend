
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/29/2015 17:34:46
-- Generated from EDMX file: C:\Users\alozano\Desktop\ASP\Intranet-Backend\Intranet-Backend\Model\intranet.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [itbs];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserEstudio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EstudioSet] DROP CONSTRAINT [FK_UserEstudio];
GO
IF OBJECT_ID(N'[dbo].[FK_UserExprecienciaLaboral]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExprecienciaLaboralSet] DROP CONSTRAINT [FK_UserExprecienciaLaboral];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCertificado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CertificadoSet] DROP CONSTRAINT [FK_UserCertificado];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursosSet] DROP CONSTRAINT [FK_UserCurso];
GO
IF OBJECT_ID(N'[dbo].[FK_UserSolicitudVacaciones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudVacacionesSet] DROP CONSTRAINT [FK_UserSolicitudVacaciones];
GO
IF OBJECT_ID(N'[dbo].[FK_RolUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_RolUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CertificadoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CertificadoSet];
GO
IF OBJECT_ID(N'[dbo].[CursosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CursosSet];
GO
IF OBJECT_ID(N'[dbo].[EstudioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstudioSet];
GO
IF OBJECT_ID(N'[dbo].[ExprecienciaLaboralSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExprecienciaLaboralSet];
GO
IF OBJECT_ID(N'[dbo].[SolicitudVacacionesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SolicitudVacacionesSet];
GO
IF OBJECT_ID(N'[dbo].[RolSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolSet1];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CertificadoSet'
CREATE TABLE [dbo].[CertificadoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [User_Usename] nvarchar(max)  NOT NULL,
    [User_Id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CursosSet'
CREATE TABLE [dbo].[CursosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [User_Usename] nvarchar(max)  NOT NULL,
    [User_Id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EstudioSet'
CREATE TABLE [dbo].[EstudioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Ano_Finalizacion] nvarchar(max)  NOT NULL,
    [User_Usename] nvarchar(max)  NOT NULL,
    [User_Id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ExprecienciaLaboralSet'
CREATE TABLE [dbo].[ExprecienciaLaboralSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CantidadAnos] smallint  NOT NULL,
    [Desempeno] nvarchar(max)  NOT NULL,
    [User_Usename] nvarchar(max)  NOT NULL,
    [User_Id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SolicitudVacacionesSet'
CREATE TABLE [dbo].[SolicitudVacacionesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha_Inicio] datetime  NOT NULL,
    [Duracion] smallint  NOT NULL,
    [User_Usename] nvarchar(max)  NOT NULL,
    [User_Id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RolSet1'
CREATE TABLE [dbo].[RolSet1] (
    [Nombre] nvarchar(max)  NOT NULL,
    [Id] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Correo] nvarchar(max)  NOT NULL,
    [ModeloVehiculo] nvarchar(max)  NULL,
    [ColorVehiculo] nvarchar(max)  NULL,
    [AnoVehiculo] nvarchar(max)  NULL,
    [PlacaVehiculo] nvarchar(max)  NULL,
    [Usename] nvarchar(max)  NOT NULL,
    [Foto] nvarchar(max)  NULL,
    [CorreoPersonal] nvarchar(max)  NULL,
    [Id] nvarchar(max)  NOT NULL,
    [Rol_Id] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CertificadoSet'
ALTER TABLE [dbo].[CertificadoSet]
ADD CONSTRAINT [PK_CertificadoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CursosSet'
ALTER TABLE [dbo].[CursosSet]
ADD CONSTRAINT [PK_CursosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EstudioSet'
ALTER TABLE [dbo].[EstudioSet]
ADD CONSTRAINT [PK_EstudioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExprecienciaLaboralSet'
ALTER TABLE [dbo].[ExprecienciaLaboralSet]
ADD CONSTRAINT [PK_ExprecienciaLaboralSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SolicitudVacacionesSet'
ALTER TABLE [dbo].[SolicitudVacacionesSet]
ADD CONSTRAINT [PK_SolicitudVacacionesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RolSet1'
ALTER TABLE [dbo].[RolSet1]
ADD CONSTRAINT [PK_RolSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Usename], [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Usename], [Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Usename], [User_Id] in table 'EstudioSet'
ALTER TABLE [dbo].[EstudioSet]
ADD CONSTRAINT [FK_UserEstudio]
    FOREIGN KEY ([User_Usename], [User_Id])
    REFERENCES [dbo].[UserSet]
        ([Usename], [Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEstudio'
CREATE INDEX [IX_FK_UserEstudio]
ON [dbo].[EstudioSet]
    ([User_Usename], [User_Id]);
GO

-- Creating foreign key on [User_Usename], [User_Id] in table 'ExprecienciaLaboralSet'
ALTER TABLE [dbo].[ExprecienciaLaboralSet]
ADD CONSTRAINT [FK_UserExprecienciaLaboral]
    FOREIGN KEY ([User_Usename], [User_Id])
    REFERENCES [dbo].[UserSet]
        ([Usename], [Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserExprecienciaLaboral'
CREATE INDEX [IX_FK_UserExprecienciaLaboral]
ON [dbo].[ExprecienciaLaboralSet]
    ([User_Usename], [User_Id]);
GO

-- Creating foreign key on [User_Usename], [User_Id] in table 'CertificadoSet'
ALTER TABLE [dbo].[CertificadoSet]
ADD CONSTRAINT [FK_UserCertificado]
    FOREIGN KEY ([User_Usename], [User_Id])
    REFERENCES [dbo].[UserSet]
        ([Usename], [Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCertificado'
CREATE INDEX [IX_FK_UserCertificado]
ON [dbo].[CertificadoSet]
    ([User_Usename], [User_Id]);
GO

-- Creating foreign key on [User_Usename], [User_Id] in table 'CursosSet'
ALTER TABLE [dbo].[CursosSet]
ADD CONSTRAINT [FK_UserCurso]
    FOREIGN KEY ([User_Usename], [User_Id])
    REFERENCES [dbo].[UserSet]
        ([Usename], [Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCurso'
CREATE INDEX [IX_FK_UserCurso]
ON [dbo].[CursosSet]
    ([User_Usename], [User_Id]);
GO

-- Creating foreign key on [User_Usename], [User_Id] in table 'SolicitudVacacionesSet'
ALTER TABLE [dbo].[SolicitudVacacionesSet]
ADD CONSTRAINT [FK_UserSolicitudVacaciones]
    FOREIGN KEY ([User_Usename], [User_Id])
    REFERENCES [dbo].[UserSet]
        ([Usename], [Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSolicitudVacaciones'
CREATE INDEX [IX_FK_UserSolicitudVacaciones]
ON [dbo].[SolicitudVacacionesSet]
    ([User_Usename], [User_Id]);
GO

-- Creating foreign key on [Rol_Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_RolUser]
    FOREIGN KEY ([Rol_Id])
    REFERENCES [dbo].[RolSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolUser'
CREATE INDEX [IX_FK_RolUser]
ON [dbo].[UserSet]
    ([Rol_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------