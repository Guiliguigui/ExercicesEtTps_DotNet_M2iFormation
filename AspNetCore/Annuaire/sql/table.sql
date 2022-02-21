DROP TABLE contact

CREATE TABLE contact(
id int PRIMARY KEY IDENTITY(1,1),
firstname varchar(100) not null,
lastname varchar(100) not null,
phone varchar(17) not null
);

INSERT INTO [dbo].contact ([firstname], [lastname], [phone]) 
VALUES ( N'Di Persio', N'Anthony', N'+33 6 85 74 12 36'),
       ( N'Abadi', N'Ihab', N'+33 6 74 12 58 96')