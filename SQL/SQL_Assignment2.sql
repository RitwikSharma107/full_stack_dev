USE AdventureWorks2019;
GO

-- 1) How many products can you find in the Production.Product table?
SELECT COUNT(ProductID) AS 'CountedProducts'
FROM Production.Product;

-- 2) Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(ProductID) AS 'CountedProducts'
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL;

-- 3) How many Products reside in each SubCategory? Write a query to display the results with the following titles: ProductSubcategoryID CountedProducts
SELECT ProductSubcategoryID, COUNT(ProductID) AS 'CountedProducts'
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID;

-- 4) How many products that do not have a product subcategory.
SELECT COUNT(ProductID) AS 'CountedProducts'
FROM Production.Product
WHERE ProductSubcategoryID IS NULL;

-- 5) Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT ProductID, SUM(Quantity) AS 'TheSum'
FROM Production.ProductInventory
GROUP BY ProductID;

-- 6) Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
SELECT ProductID, SUM(Quantity) AS 'TheSum'
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100;

--  7) Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
SELECT Shelf, ProductID, SUM(Quantity) AS 'TheSum'
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100;

-- 8) Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT ProductID, AVG(Quantity) AS 'TheAvg'
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID;

-- 9) Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS 'TheAvg'
FROM Production.ProductInventory
GROUP BY ProductID, Shelf;

-- 10) Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS 'TheAvg'
FROM Production.ProductInventory
GROUP BY ProductID, Shelf
HAVING Shelf != 'N/A';

-- 11) List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
SELECT Color, Class, COUNT(*) AS 'TheCount',  AVG(ListPrice) AS 'AvgPrice'
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class;

-- 12) Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.
SELECT c.Name AS 'Country', s.Name AS 'Province'
FROM person.CountryRegion c
INNER JOIN person.StateProvince s
ON c.CountryRegionCode = s.CountryRegionCode;

-- 13) Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT c.Name AS 'Country', s.Name AS 'Province'
FROM person.CountryRegion c
INNER JOIN person.StateProvince s
ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name = 'Germany' OR c.Name = 'Canada'; 

USE Northwind;
GO

-- 14) List all Products that has been sold at least once in last 25 years.
SELECT p.ProductName, o.OrderDate FROM Products p 
JOIN [Order Details] od ON p.ProductID = od.ProductID 
JOIN Orders o ON o.OrderID = od.OrderID
WHERE o.OrderDate > DATEADD(YEAR, -27, GETDATE())
ORDER BY o.OrderDate;


-- 15) List top 5 locations (Zip Code) where the products sold most.
SELECT TOP 5 o.ShipPostalCode, COUNT(o.OrderID) AS 'NUM_OF_PRODUCTS'
FROM Products p
INNER JOIN [Order Details] od
ON p.ProductID = od.ProductID
INNER JOIN Orders o 
ON od.OrderID = o.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY o.ShipPostalCode
ORDER BY COUNT(p.ProductID) DESC;

-- 16) List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT TOP 5 ShipPostalCode AS ZipCode, COUNT(ShipPostalCode) AS Sold 
FROM Orders
WHERE DATEDIFF(year, OrderDate, GETDATE()) < 27
GROUP BY ShipPostalCode
ORDER BY COUNT(ShipPostalCode) DESC;

-- 17) List all city names and number of customers in that city.     
SELECT City, COUNT(CustomerID) AS NoOfCustomers 
FROM Customers
GROUP BY City;

-- 18) List city names which have more than 2 customers, and number of customers in that city
SELECT City, COUNT(CustomerID) AS NoOfCustomers 
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) > 2;

-- 19) List the names of customers who placed orders after 1/1/98 with order date.
SELECT c.ContactName, o.OrderDate 
FROM Customers c 
JOIN Orders o ON o.CustomerID = c.CustomerID
WHERE o.OrderDate > '1/1/98';

-- 20) List the names of all customers with most recent order dates
SELECT c.ContactName, o.OrderDate 
FROM Customers c 
JOIN Orders o ON o.CustomerID = c.CustomerID
ORDER BY o.OrderDate DESC;

-- 21) Display the names of all customers  along with the  count of products they bought
SELECT c.ContactName, COUNT(od.ProductID) AS ProductCount 
FROM Customers c 
JOIN Orders o ON o.CustomerID = c.CustomerID 
JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.ContactName;


-- 22) Display the customer ids who bought more than 100 Products with count of products.
SELECT c.ContactName, COUNT(od.ProductID) AS ProductCount 
FROM Customers c 
JOIN Orders o ON o.CustomerID = c.CustomerID 
JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.ContactName
HAVING COUNT(od.ProductID) > 100;

-- 23) List all of the possible ways that suppliers can ship their products. Display the results as below

SELECT DISTINCT su.CompanyName AS Supplier, s.CompanyName AS Shipper 
FROM Suppliers su 
JOIN Products p ON su.SupplierID = p.SupplierID 
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
JOIN Shippers s ON o.ShipVia = s.ShipperID;


-- 24) Display the products order each day. Show Order date and Product Name.
SELECT 
    o.OrderDate,
    p.ProductName
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
ORDER BY o.OrderDate, p.ProductName;



-- 25) Displays pairs of employees who have the same job title.
SELECT e1.FirstName, e2.FirstName, e1.Title 
FROM Employees e1 
JOIN Employees e2 
ON e1.Title = e2.Title AND e1.FirstName < e2.FirstName;

-- 26) Display all the Managers who have more than 2 employees reporting to them.
SELECT e.FirstName 
FROM Employees e
INNER JOIN (
    SELECT ReportsTo, COUNT(ReportsTo) AS 'Number of Employees' 
    FROM Employees
    GROUP BY ReportsTo
    HAVING COUNT(ReportsTo) > 2
) dt
ON e.EmployeeID = dt.ReportsTo;

-- 27) Display the customers and suppliers by city. The results should have the following columns
-- City
-- Name
-- Contact Name,
-- Type (Customer or Supplier)
WITH Cte AS (
    SELECT 
        City,
        CompanyName AS Name,
        ContactName,
        'Customer' AS Type
    FROM Customers
    UNION ALL
    SELECT 
        City,
        CompanyName AS Name,
        ContactName,
        'Supplier' AS Type
    FROM Suppliers
)
SELECT * 
FROM Cte;