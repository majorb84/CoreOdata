USE CoreOdata
GO

SELECT * FROM dbo.[Types]
SELECT * FROM dbo.Models
SELECT * FROM dbo.Vehicles

BEGIN TRANSACTION

INSERT INTO dbo.[Types] (Name)
VALUES
	('Truck'),
	('Sedan'),
	('Coupé'),
	('SUV'),
	('Convertible')
GO

INSERT INTO dbo.Models(Name)
VALUES
	('Ford'),
	('Toyota'),
	('Volvo'),
	('Nissan'),
	('Tesla')
GO

DECLARE @Truck INT = (SELECT Id FROM dbo.[Types] WHERE Name = 'Truck')
DECLARE @Sedan INT = (SELECT Id FROM dbo.[Types] WHERE Name = 'Sedan')
DECLARE @Coupe INT = (SELECT Id FROM dbo.[Types] WHERE Name = 'Coupé')
DECLARE @SUV INT = (SELECT Id FROM dbo.[Types] WHERE Name = 'SUV')
DECLARE @Convertible INT = (SELECT Id FROM dbo.[Types] WHERE Name = 'Convertible')
DECLARE @Ford INT = (SELECT Id FROM dbo.Models WHERE Name = 'Ford')
DECLARE @Toyota INT = (SELECT Id FROM dbo.Models WHERE Name = 'Toyota')
DECLARE @Volvo INT = (SELECT Id FROM dbo.Models WHERE Name = 'Volvo')
DECLARE @Nissan INT = (SELECT Id FROM dbo.Models WHERE Name = 'Nissan')
DECLARE @Tesla INT = (SELECT Id FROM dbo.Models WHERE Name = 'Tesla')


INSERT INTO dbo.Vehicles (TypeId, ModelId, [Year], Color, IsAntique)
VALUES 
	(@Truck, @Ford, 1994, 'White', 0),
	(@SUV, @Nissan, 2017, 'Blue', 0),
	(@Convertible, @Ford, 2016, 'Red', 0),
	(@Coupe, @Tesla, 2018, 'Red', 0),
	(@Sedan, @Volvo, 2013, 'Brown', 0)

SELECT * FROM dbo.[Types]
SELECT * FROM dbo.Models
SELECT * FROM dbo.Vehicles

--ROLLBACK TRANSACTION
COMMIT TRANSACTION
