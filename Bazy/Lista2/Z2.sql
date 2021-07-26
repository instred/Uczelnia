DROP TABLE IF EXISTS imiona
GO

CREATE TABLE imiona(id INT PRIMARY KEY, imie CHAR(20))
GO

INSERT INTO imiona VALUES(1, 'tomasz')
INSERT INTO imiona VALUES(2, 'dawid')
INSERT INTO imiona VALUES(3, 'kacper')
INSERT INTO imiona VALUES(4, 'mateusz')

GO

DROP TABLE IF EXISTS nazwiska
GO

CREATE TABLE nazwiska(id INT PRIMARY KEY, nazwisko CHAR(20))
GO

INSERT INTO nazwiska VALUES(1, 'nowak')
INSERT INTO nazwiska VALUES(2, 'jaki')
INSERT INTO nazwiska VALUES(3, 'kowalski')
INSERT INTO nazwiska VALUES(4, 'zawrocki')

GO

DROP PROCEDURE IF EXISTS exercise2proc
GO

CREATE PROCEDURE exercise2proc @n INT AS
BEGIN
	DROP TABLE IF EXISTS dane
	CREATE TABLE dane(imie CHAR(20), nazwisko CHAR(20))
	
	DECLARE @iterator INT
	SET @iterator = 1

	DECLARE @imiona	INT
	DECLARE @nazwiska INT
	SET @imiona   = (SELECT COUNT(id) FROM Test.dbo.imiona)
	SET @nazwiska = (SELECT COUNT(id) FROM Test.dbo.nazwiska)

	IF (@n > (@imiona*@nazwiska))
		BEGIN
			;THROW 50001, 'n jest wieksze od wszystkich mozliwosci', 1;
		END

	WHILE (@iterator <= @n)
	BEGIN
		DECLARE @imie	  CHAR(20)
		DECLARE @nazwisko CHAR(20)
		SET @imie	  = (SELECT TOP 1 imie FROM imiona ORDER BY NEWID())
		SET @nazwisko = (SELECT TOP 1 nazwisko FROM nazwiska ORDER BY NEWID())

		IF NOT EXISTS (SELECT * FROM dane WHERE imie = @imie AND nazwisko = @nazwisko)
		BEGIN
			INSERT INTO dane VALUES(@imie, @nazwisko)
			SET @iterator = @iterator + 1
		END
	END

	SELECT * FROM dane
END
GO

EXEC exercise2proc @n = 5
GO

