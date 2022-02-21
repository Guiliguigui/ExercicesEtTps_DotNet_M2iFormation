/*
* Injection Clients
*/



INSERT INTO [dbo].[clientBanque] ( [nom], [prenom], [telephone]) VALUES ( N'Di Persio', N'Anthony', N'+33 6 45 78 96 52')
INSERT INTO [dbo].[clientBanque] ( [nom], [prenom], [telephone]) VALUES ( N'Abadi', N'Ihab', N'+33 6 41 23 58 74')
INSERT INTO [dbo].[clientBanque] ( [nom], [prenom], [telephone]) VALUES ( N'Abadi', N'Marine', N'+33 6 45 47 12 36')



/*
* Injection Comptes
*/



INSERT INTO [dbo].[compte] ( [solde], [taux], [coutOperation]) VALUES ( CAST(780.00 AS Decimal(10, 2)), CAST(0.0 AS Decimal(2, 1)), CAST(0.00 AS Decimal(4, 2)))
INSERT INTO [dbo].[compte] ( [solde], [taux], [coutOperation]) VALUES ( CAST(447.81 AS Decimal(10, 2)), CAST(4.0 AS Decimal(2, 1)), CAST(0.00 AS Decimal(4, 2)))
INSERT INTO [dbo].[compte] ( [solde], [taux], [coutOperation]) VALUES ( CAST(432.00 AS Decimal(10, 2)), CAST(0.0 AS Decimal(2, 1)), CAST(2.00 AS Decimal(4, 2)))



/*
* Injection ClientCompte
*/



INSERT INTO [dbo].[clientCompte] ( [idClient], [idCompte]) VALUES ( 1, 1)
INSERT INTO [dbo].[clientCompte] ( [idClient], [idCompte]) VALUES ( 2, 2)
INSERT INTO [dbo].[clientCompte] ( [idClient], [idCompte]) VALUES ( 3, 3)



/*
* Injection Opérations
*/



INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'1', N'2022-01-17 14:13:00', CAST(50.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'2', N'2022-01-17 14:13:04', CAST(50.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'1', N'2022-01-17 14:13:13', CAST(-30.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'2', N'2022-01-17 14:13:17', CAST(-30.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'3', N'2022-01-17 14:13:21', CAST(-30.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'3', N'2022-01-17 14:13:21', CAST(-2.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'2', N'2022-01-17 14:13:25', CAST(12.80 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'3', N'2022-01-17 14:20:21', CAST(50.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'3', N'2022-01-17 14:20:28', CAST(-2.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'2', N'2022-01-17 14:21:24', CAST(50.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'2', N'2022-01-19 16:47:10', CAST(15.31 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'2', N'2022-01-19 16:50:52', CAST(15.92 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'2', N'2022-01-19 16:52:21', CAST(50.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'2', N'2022-01-19 16:52:30', CAST(-50.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'1', N'2022-01-19 17:01:25', CAST(120.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'1', N'2022-01-19 17:01:32', CAST(-60.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'1', N'2022-01-19 17:05:10', CAST(500.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'3', N'2022-01-19 17:06:47', CAST(70.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'3', N'2022-01-19 17:06:47', CAST(-2.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'3', N'2022-01-19 17:06:53', CAST(-50.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'3', N'2022-01-19 17:06:53', CAST(-2.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'2', N'2022-01-19 17:07:08', CAST(16.56 AS Decimal(10, 2)))
INSERT INTO [dbo].[operation] ( [idcompte], [dateOperation], [montant]) VALUES ( N'2', N'2022-01-19 17:07:15', CAST(17.22 AS Decimal(10, 2)))