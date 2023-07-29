-- Brand tablosunu oluştur
CREATE TABLE Brand
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255)
);

-- Model tablosunu oluştur
CREATE TABLE Model
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255),
    BrandId INT,
    FOREIGN KEY (BrandId) REFERENCES Brand(Id)
);


-- BodyKit tablosunu oluştur
CREATE TABLE BodyKit
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    BodyType NVARCHAR(255)
);

CREATE TABLE Car(
	Id INT PRIMARY KEY IDENTITY(1,1),
	BrandId INT,
	ModelId INT,
	BodyKitId INT,
	WindowCount INT,
	DoorCount INT,
	FOREIGN KEY (BrandId) REFERENCES Brand(Id),
	FOREIGN KEY (ModelId) REFERENCES Model(Id),
	FOREIGN KEY (BodyKitId) REFERENCES BodyKit(Id)
);


-- Brand tablosuna örnek veriler ekle
INSERT INTO Brand (Title)
VALUES
    ('Toyota'),
    ('Honda'),
    ('Ford');

-- Model tablosuna örnek veriler ekle
INSERT INTO Model (Title, BrandId)
VALUES
    ('Camry', 1),
    ('Accord', 2),
    ('Civic', 2),
    ('F-150', 3),
    ('RAV4', 1);

-- BodyKit tablosuna örnek veriler ekle
INSERT INTO BodyKit (BodyType)
VALUES
    ('Sedan'),
    ('Coupe'),
    ('Truck'),
    ('SUV');

-- Car tablosuna örnek veriler ekle
INSERT INTO Car (BrandId, ModelId, BodyKitId, WindowCount, DoorCount)
VALUES
    (1, 1, 1, 4, 4),
    (2, 2, 2, 2, 2),
    (3, 4, 3, 4, 2),
    (1, 5, 4, 4, 4),
    (2, 3, 1, 2, 4);
