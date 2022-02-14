DROP TABLE forum;
CREATE TABLE forum(
id int PRIMARY KEY IDENTITY(1,1),
nom varchar(100) not null,
dateCreation DATETIME not null
);

DROP TABLE nouvelle;
CREATE TABLE nouvelle(
id int PRIMARY KEY IDENTITY(1,1),
sujet varchar(100) not null,
texte_descriptif varchar(100) not null,
abonne_id int not null,
forum_id int not null
);

DROP TABLE abonne;
CREATE TABLE abonne (
id int PRIMARY KEY IDENTITY(1,1),
nom varchar(100) not null,
prenom varchar(100) not null,
forum_id int not null
);

DROP TABLE moderateur;
CREATE TABLE moderateur (
id int PRIMARY KEY IDENTITY(1,1),
abonne_id int not null
);