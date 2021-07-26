SELECT DISTINCT City
FROM [SalesLT].[Address] JOIN [SalesLT].[SalesOrderHeader]
ON [SalesLT].[SalesOrderHeader].ShipToAddressID = [SalesLT].[Address].AddressID
WHERE ShipDate <= '2021-03-16'
ORDER BY City ASC