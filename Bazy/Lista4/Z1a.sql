DROP TABLE IF EXISTS tabelka

CREATE TABLE tabelka
(
	Id INT PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	ItemsinStock INT NOT NULL

)

INSERT into tabelka

VALUES 
(1, 'Laptop', 12),
(2, 'iPhone', 15),
(3, 'Tablets', 10)


BEGIN Tran

UPDATE tabelka set ItemsInStock = 11
WHERE Id = 1

-- Billing the customer
WaitFor Delay '00:00:10'
Rollback Transaction

-- Second SSMS
-- SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 
SELECT * FROM tabelka
WHERE Id = 1