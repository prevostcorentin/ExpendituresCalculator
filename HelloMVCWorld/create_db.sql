USE SpentDb
GO
 
DROP TABLE IF EXISTS Spents

CREATE TABLE Spents
(
	"SpentId" UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	"Name" VARCHAR (50),
	"Amount" Float,
	"DateTime" DateTime
)
GO
 
INSERT INTO Spents VALUES (default,'Socks',50.045,GETDATE())
INSERT INTO Spents VALUES (default,'Socks',50.045,GETDATE())
INSERT INTO Spents VALUES (default,'Socks',50.045,GETDATE())