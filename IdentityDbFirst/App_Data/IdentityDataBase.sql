USE [aspnet-IdentityCodeFirst]

GO
ALTER TABLE [dbo].[IdentityUserRoles] DROP CONSTRAINT [FK_IdentityUserRoles_IdentityUsers_UserId]
GO
ALTER TABLE [dbo].[IdentityUserRoles] DROP CONSTRAINT [FK_IdentityUserRoles_IdentityRoles_RoleId]
GO
ALTER TABLE [dbo].[IdentityUserLogins] DROP CONSTRAINT [FK_IdentityUserLogins_IdentityUsers_UserId]
GO
ALTER TABLE [dbo].[IdentityUserClaims] DROP CONSTRAINT [FK_IdentityUserClaims_IdentityUsers_UserId]
GO

/****** Drop Identity Tables ******/
DROP TABLE [dbo].[IdentityUsers]
GO
DROP TABLE [dbo].[IdentityUserRoles]
GO
DROP TABLE [dbo].[IdentityUserLogins]
GO
DROP TABLE [dbo].[IdentityUserClaims]
GO
DROP TABLE [dbo].[IdentityRoles]
GO

/****** Object:  Table [dbo].[IdentityRoles] ******/
CREATE TABLE [dbo].[IdentityRoles](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](256) NOT NULL,
    CONSTRAINT [PK_IdentityRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

/****** Object:  Table [dbo].[IdentityUserClaims] ******/
CREATE TABLE [dbo].[IdentityUserClaims](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [UserId] [int] NOT NULL,
    [ClaimType] [nvarchar](max) NULL,
    [ClaimValue] [nvarchar](max) NULL,
    CONSTRAINT [PK_IdentityUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

/****** Object:  Table [dbo].[IdentityUserLogins] ******/
CREATE TABLE [dbo].[IdentityUserLogins](
    [LoginProvider] [nvarchar](128) NOT NULL,
    [ProviderKey] [nvarchar](128) NOT NULL,
    [UserId] [int] NOT NULL,
    CONSTRAINT [PK_IdentityUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC,[ProviderKey] ASC,[UserId] ASC)
);
GO

/****** Object:  Table [dbo].[IdentityUsers] ******/
CREATE TABLE [dbo].[IdentityUsers](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Email] [nvarchar](256) NULL,
    [EmailConfirmed] [bit] NOT NULL,
    [PasswordHash] [nvarchar](100) NULL,
    [SecurityStamp] [nvarchar](100) NULL,
    [PhoneNumber] [nvarchar](25) NULL,
    [PhoneNumberConfirmed] [bit] NOT NULL,
    [TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEndDateUtc] [datetime] NULL,
    [LockoutEnabled] [bit] NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
    CONSTRAINT [PK_IdentityUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

/****** Object:  Table [dbo].[IdentityUserRoles] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserRoles](
    [UserId] [int] NOT NULL,
    [RoleId] [int] NOT NULL,
    CONSTRAINT [PK_IdentityUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC,[RoleID] ASC)
);
GO

ALTER TABLE [dbo].[IdentityUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserClaims_IdentityUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserClaims] CHECK CONSTRAINT [FK_IdentityUserClaims_IdentityUsers_UserId]
GO

ALTER TABLE [dbo].[IdentityUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserLogins_IdentityUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserLogins] CHECK CONSTRAINT [FK_IdentityUserLogins_IdentityUsers_UserId]
GO

ALTER TABLE [dbo].[IdentityUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRoles_IdentityRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[IdentityRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserRoles] CHECK CONSTRAINT [FK_IdentityUserRoles_IdentityRoles_RoleId]
GO

ALTER TABLE [dbo].[IdentityUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRoles_IdentityUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[IdentityUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IdentityUserRoles] CHECK CONSTRAINT [FK_IdentityUserRoles_IdentityUsers_UserId]
GO
