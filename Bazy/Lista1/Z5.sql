SELECT 
    SalesLT.Customer.FirstName, SalesLT.Customer.LastName, SUM(SalesLT.SalesOrderDetail.UnitPriceDiscount) AS Discount
	
FROM
    [SalesLT].[Customer],
    [SalesLT].[SalesOrderDetail],
    [SalesLT].[SalesOrderHeader]
WHERE
     SalesLT.Customer.CustomerID = SalesLT.SalesOrderHeader.CustomerID
    AND SalesLT.SalesOrderDetail.SalesOrderID = SalesLT.SalesOrderHeader.SalesOrderID
GROUP BY SalesLT.Customer.FirstName, SalesLT.Customer.LastName
ORDER BY Discount DESC