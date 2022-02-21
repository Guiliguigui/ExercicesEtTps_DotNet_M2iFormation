Drop TABLE clientBanque;
Drop TABLE clientCompte;
Drop TABLE compte;
Drop TABLE operation;
/*
 * Création table Utilisateur
 */
CREATE TABLE [dbo].[clientBanque]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [nom] VARCHAR(50) NOT NULL, 
    [prenom] VARCHAR(50) NOT NULL, 
    [telephone] VARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)
/*
 * Création table Compte
 */
CREATE TABLE [dbo].[compte]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,       
    [solde]  DECIMAL (10, 2) NOT NULL,
    [taux]   DECIMAL  (2, 1) NOT NULL,
    [coutOperation]   DECIMAL  (4, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)
/*
 * Création table Clientcompte
 */
CREATE TABLE [dbo].[clientCompte]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [idClient]       INT    NOT NULL,    
    [idCompte]       INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)
/*
 * Création table opération
 */
CREATE TABLE [dbo].[operation]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
    [idcompte]    VARCHAR (50) NOT NULL,
    [dateOperation] DATETIME     NOT NULL,
    [montant]      DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)