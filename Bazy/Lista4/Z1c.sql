-- SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


DROP TABLE IF EXISTS Samochody
GO

CREATE TABLE Samochody (Model VARCHAR(20), Marka VARCHAR(20))
INSERT INTO Samochody VALUES('Opel',  'Astra')
INSERT INTO Samochody VALUES('Opel',  'Meriva')
INSERT INTO Samochody VALUES('Skoda', 'Fabia')
INSERT INTO Samochody VALUES('Skoda', 'Superb')
INSERT INTO Samochody VALUES('Skoda', 'Felicia')
GO

/*
Sposób dzia³ania jak wy¿ej, jednak przy odczytach zmienia siê liczba odczytywanych danych
spowodowana dzia³aniem INSERT lub DELETE.
*/

-- Transakcja 1 --
BEGIN TRAN
SELECT * FROM Samochody
WAITFOR DELAY '00:00:05'
SELECT * FROM Samochody
ROLLBACK

-- Transakcja 2 --
BEGIN TRAN
DELETE FROM Samochody WHERE Model = 'Opel'
COMMIT
GO
