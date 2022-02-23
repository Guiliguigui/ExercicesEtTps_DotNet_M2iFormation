DROP TABLE [dbo].[users];

CREATE TABLE [dbo].[users]
( 
	id INT IDENTITY(1,1) NOT NULL,
	isAdmin BIT NOT NULL,
	nickName VARCHAR(250) NOT NULL ,
	firstName VARCHAR(250) NOT NULL ,
	lastName VARCHAR(250) NOT NULL ,
	email VARCHAR(250) NOT NULL ,
	phone VARCHAR(17) NOT NULL ,
	password VARCHAR(50) NOT NULL ,
	PRIMARY KEY CLUSTERED (id ASC)
);

DROP TABLE [dbo].[topic];

CREATE TABLE [dbo].[topic]
( 
	id INT IDENTITY(1,1) NOT NULL,
	dateCreation DATETIME NOT NULL,
	authorId INT NOT NULL ,
	subject VARCHAR(250) NOT NULL ,
	text VARCHAR(MAX) NOT NULL ,
	PRIMARY KEY CLUSTERED (id ASC)
);

DROP TABLE [dbo].[message];

CREATE TABLE [dbo].[message]
( 
	id INT IDENTITY(1,1) NOT NULL,
	dateCreation DATETIME NOT NULL,
	authorId INT NOT NULL ,
	subject VARCHAR(250) NOT NULL ,
	text VARCHAR(MAX) NOT NULL ,
	topic INT NOT NULL,
	PRIMARY KEY CLUSTERED (id ASC)
);

INSERT INTO [dbo].[users] (isAdmin, nickName, firstName, lastName, email, phone, password)
VALUES (1, N'DefalutAdmin', N'firstName', N'lastName', 'admin@forum', '+33 6 66 13 66 60', 'azerty123');

INSERT INTO [dbo].[topic] (dateCreation, authorId, subject, text)
VALUES (GETDATE(), 1, N'subject', 'text');

INSERT INTO [dbo].[message] (dateCreation, authorId, subject, text, topic)
VALUES (GETDATE(), 1, N'subject', 'text', 1);


SELECT * FROM [dbo].[users];
SELECT * FROM [dbo].[topic];
SELECT * FROM [dbo].[message];

