DROP TABLE IF EXISTS Prices
GO

DROP TABLE IF EXISTS Products
GO

DROP TABLE IF EXISTS Rates
GO

CREATE TABLE Products(ID INT PRIMARY KEY, ProductName VARCHAR(50))
GO

INSERT INTO Products VALUES(1, 'krzeslo_drewniane')
INSERT INTO Products VALUES(2, 'krzeslo_metalowe')
INSERT INTO Products VALUES(3, 'krzeslo_plastikowe')
GO


CREATE TABLE Rates(Currency VARCHAR(3) PRIMARY KEY, PricePLN MONEY)
GO

INSERT INTO Rates VALUES('PLN', 1.00)
INSERT INTO Rates VALUES('EUR', 4.67)
INSERT INTO Rates VALUES('GBP', 5.46)
INSERT INTO Rates VALUES('CHF', 4.23)
INSERT INTO Rates VALUES('USD', 3.95)

GO

CREATE TABLE Prices(ProductID INT REFERENCES Products(ID), Currency VARCHAR(3) REFERENCES Rates(Currency), Price MONEY)
GO

INSERT INTO Prices VALUES(1, 'PLN', 199.99)
INSERT INTO Prices VALUES(2, 'PLN', 149.99)
INSERT INTO Prices VALUES(3, 'PLN', 59.99)
INSERT INTO Prices VALUES(1, 'GBP', 32.63)
INSERT INTO Prices VALUES(1, 'EUR', 41.82)
INSERT INTO Prices VALUES(1, 'CHF', 47.28)
INSERT INTO Prices VALUES(2, 'USD', 1.63)
INSERT INTO Prices VALUES(3, 'EUR', 15.84)
GO 



ALTER TABLE Prices NOCHECK CONSTRAINT ALL
DELETE from Rates WHERE Currency = 'USD'
ALTER TABLE Prices CHECK CONSTRAINT ALL
GO

DECLARE prod CURSOR FOR SELECT ProductID, Currency, Price FROM Prices ORDER BY ProductID
DECLARE curr CURSOR FOR SELECT Currency, PricePLN FROM Rates

DECLARE @Prod_prodid INT, @Prod_curr VARCHAR(3), @Prod_pricePLN MONEY
DECLARE @Current_prodid INT, @Current_pricePLN MONEY
DECLARE @R_curr VARCHAR(3), @R_pricePLN MONEY
DECLARE @delete BIT

OPEN prod
FETCH NEXT FROM prod INTO @Prod_prodid, @Prod_curr, @Prod_pricePLN
SET @Current_prodid = @Prod_prodid
SET @Current_pricePLN = (SELECT Price from Prices WHERE ProductID = @Current_prodid AND Currency = 'PLN')
WHILE (@@FETCH_STATUS = 0)
BEGIN
	OPEN curr
	FETCH NEXT FROM curr INTO @R_curr, @R_pricePLN
	SET @delete = 1
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF (@Prod_curr = @R_curr)
		BEGIN
			SET @Prod_pricePLN = @Current_pricePLN / @R_pricePLN
			UPDATE Prices SET Price = @Prod_pricePLN WHERE ProductID = @Prod_prodid AND Currency = @Prod_curr
			SET @delete = 0
		END
		FETCH NEXT FROM curr INTO @R_curr, @R_pricePLN
	END
	IF @delete=1
		DELETE FROM Prices WHERE ProductID = @Prod_prodid AND Currency = @Prod_curr
	CLOSE curr
	FETCH NEXT FROM prod INTO @Prod_prodid, @Prod_curr, @Prod_pricePLN
	IF @Current_prodid != @Prod_prodid
	BEGIN
		SET @Current_prodid = @Prod_prodid
		SET @Current_pricePLN = (SELECT Price from Prices WHERE ProductID = @Current_prodid AND Currency = 'PLN')
	END
END
CLOSE prod
DEALLOCATE curr
DEALLOCATE prod
GO

SELECT * FROM Prices ORDER BY ProductID, Currency DESC
GO