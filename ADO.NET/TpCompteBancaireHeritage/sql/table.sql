DROP TABLE client;
CREATE TABLE client(
id int PRIMARY KEY IDENTITY(1,1),
nom varchar(100) not null,
prenom varchar(100) not null,
telephone varchar(10) not null
);

DROP TABLE operation;
CREATE TABLE operation(
id int PRIMARY KEY IDENTITY(1,1),
date_operation datetime not null,
montant decimal not null,
compte_id int not null
);

DROP TABLE compte;
CREATE TABLE compte (
id int PRIMARY KEY IDENTITY(1,1),
solde decimal not null,
client_id int not null,
);