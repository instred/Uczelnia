SELECT SalesLT.ProductModel.Name , COUNT(ProductModel.Name) as Counter
FROM [SalesLT].[ProductModel], [SalesLT].[Product] 
WHERE Product.ProductModelID=ProductModel.ProductModelID
GROUP BY ProductModel.Name
HAVING COUNT(*) > 1