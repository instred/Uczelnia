SELECT City, COUNT(DISTINCT Customer.CustomerID) as CustomerNumber, COUNT(DISTINCT SalesPerson) as SalesPerson 
FROM SalesLT.Customer, SalesLT.Address, SalesLT.CustomerAddress 
WHERE SalesLT.Address.AddressID=SalesLT.CustomerAddress.AddressID 
AND SalesLT.CustomerAddress.CustomerID=SalesLT.Customer.CustomerID
GROUP BY City