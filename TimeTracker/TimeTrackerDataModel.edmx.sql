
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/06/2017 12:03:02
-- Generated from EDMX file: c:\users\wiesi_000\documents\visual studio 2017\Projects\TimeTracker\TimeTracker\TimeTrackerDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\WIESI_000\DOCUMENTS\TIMETRACKERDB.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Role] int  NOT NULL
);
GO

-- Creating table 'Calendars'
CREATE TABLE [dbo].[Calendars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [EmployeeId] int  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Hours] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [CalendarId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Calendars'
ALTER TABLE [dbo].[Calendars]
ADD CONSTRAINT [PK_Calendars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeId] in table 'Calendars'
ALTER TABLE [dbo].[Calendars]
ADD CONSTRAINT [FK_EmployeeCalendar]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeCalendar'
CREATE INDEX [IX_FK_EmployeeCalendar]
ON [dbo].[Calendars]
    ([EmployeeId]);
GO

-- Creating foreign key on [CalendarId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_CalendarProject]
    FOREIGN KEY ([CalendarId])
    REFERENCES [dbo].[Calendars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalendarProject'
CREATE INDEX [IX_FK_CalendarProject]
ON [dbo].[Projects]
    ([CalendarId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------