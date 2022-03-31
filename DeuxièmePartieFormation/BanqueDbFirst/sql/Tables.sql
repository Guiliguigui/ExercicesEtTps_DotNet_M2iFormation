
--DROP TABLE client
--DROP TABLE operation
--DROP TABLE compte


CREATE TABLE client
(
	id int PRIMARY KEY IDENTITY(1,1),
	nom varchar(100) not null,
	prenom varchar(100) not null,
	telephone varchar(17) not null
);

CREATE TABLE operation
(
	id int PRIMARY KEY IDENTITY(1,1),
	date_operation datetime not null,
	montant decimal not null,
	compte_id int not null
);

CREATE TABLE compte 
(
	id int PRIMARY KEY IDENTITY(1,1),
	solde decimal not null,
	taux decimal not null,
	coutOperation decimal not null,
	client_id int not null,
);

/*
 * Insertion Clients dans la BDD
 */

INSERT INTO [dbo].[client] ( [nom], [prenom], [telephone]) 
VALUES ( N'Di Persio', N'Anthony', N'+33 6 85 74 12 36'),
	   ( N'Abadi', N'Ihab', N'+33 6 74 12 58 96'),
	   ( N'Abadi', N'Marine', N'+33 6 45 78 62 32'),
	   ( N'Dark', N'Jeanne', N'+33 6 74 85 96 32'),	   
	   ( N'Apeupré', N'Jean-Michel', N'+33 6 41 52 78 96'),	   
	   ( N'Doe', N'Janes', N'+33 6 41 52 78 54'),
	   ( N'Toto', N'Titi', N'+33 6 52 41 78 96')

/*
 * Insertion Operations dans la BDD
 */	   
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 16:22:42', CAST(150 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 16:22:52', CAST(-100 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:01:14', CAST(200 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:07:27', CAST(200 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:07:27', CAST(-3 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:13:55', CAST(450 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:14:03', CAST(-300 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:14:24', CAST(-200 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:14:24', CAST(-3 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:14:34', CAST(500 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:14:34', CAST(-3 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:18:51', CAST(250 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:18:58', CAST(300 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:19:04', CAST(-400 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:54:56', CAST(86 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:55:01', CAST(89 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-15 23:55:05', CAST(93 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:26:37', CAST(80 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:26:46', CAST(83 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:26:47', CAST(87 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:26:49', CAST(90 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:26:51', CAST(94 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:26:52', CAST(97 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:40:29', CAST(50 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:40:31', CAST(50 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:40:32', CAST(50 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:40:33', CAST(50 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:40:33', CAST(50 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:40:33', CAST(50 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:45:51', CAST(50 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:45:51', CAST(-3 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:46:21', CAST(100 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:46:41', CAST(100 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:54:08', CAST(-150 AS Decimal(18, 0)), 1)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:54:21', CAST(-150 AS Decimal(18, 0)), 2)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:54:36', CAST(-150 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 14:54:36', CAST(-3 AS Decimal(18, 0)), 3)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 15:23:52', CAST(150 AS Decimal(18, 0)), 4)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 15:23:59', CAST(-100 AS Decimal(18, 0)), 4)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 15:27:27', CAST(5 AS Decimal(18, 0)), 5)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 15:29:37', CAST(150 AS Decimal(18, 0)), 5)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 15:29:44', CAST(-120 AS Decimal(18, 0)), 5)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 15:30:36', CAST(300 AS Decimal(18, 0)), 6)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 15:30:36', CAST(-2 AS Decimal(18, 0)), 6)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 15:30:45', CAST(-300 AS Decimal(18, 0)), 6)
INSERT INTO [dbo].[operation] ( [date_operation], [montant], [compte_id]) VALUES ( N'2022-02-16 15:30:45', CAST(-2 AS Decimal(18, 0)), 6)

/*
 * Insertion Compte dans la BDD
 */
INSERT INTO [dbo].[compte] ( [solde], [taux], [coutOperation], [client_id]) 
VALUES ( CAST(1800 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1),
	   ( CAST(2481 AS Decimal(18, 0)), CAST(4 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 2),
	   ( CAST(2894 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), 3),
	   ( CAST(200 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 5),
	   ( CAST(185 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 7),
	   ( CAST(296 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)), 8),
	   ( CAST(130 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 9)

