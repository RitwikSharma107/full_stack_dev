USE Northwind;
GO -- Batch Directive

-- DDL Statements should be executed in different batch but DML can be executed in same batch
/* 
-- Batch 1
CREATE
GO

-- Batch 2
ALTER
GO

-- Batch 3
DROP
GO

-- Batch 4
SELECT 
UPDATE
DELETE
GO
*/

-- System databases --
-- master Database: Records all the system-level information for an instance of SQL Server.
-- msdb Database: Is used by SQL Server Agent for scheduling alerts and jobs.
-- model Database: Is used as the template for all databases created on the instance of SQL Server. Modifications made to the model database, such as database size, collation, recovery model, and other database options, are applied to any databases created afterward.
-- Resource Database: Is a read-only database that contains system objects that are included with SQL Server. System objects are physically persisted in the Resource database, but they logically appear in the sys schema of every database.
-- tempdb Database: Is a workspace for holding temporary objects or intermediate result sets.

-- Regular Identifier --
---- 1) First character: a-z,A-Z, @, #
------ @ => Defining a variable
DECLARE @today DATETIME
SELECT @today = GETDATE()
PRINT @today;
------ # => Local temp table
------ ## => GLobal temp table
----2) Subsequent Character: a-z, A-Z, 0-9, @, #, $
----3) Not a SQL Keyword/ Reserve word
----4) No space

-- Delimated Identifiers --
---- [] or "" 
---- Can contain spaces
SELECT EmployeeID as "Emp ID"
FROM Employees;

-- NUll Operation
SELECT CONCAT_WS(' ',City,IsNull(Region,'N/A'),Country) as "Location"
FROM Customers

-- LIKE OPERATION
---- Postal Code not starting with 1 but not followed by number in range 0 to 3
SELECT ContactName, PostalCode
FROM Customers
WHERE PostalCode LIKE '1[^0-3]%';

-- Order by using column no. [1:n]
SELECT ContactName, PostalCode
FROM Customers
ORDER BY 2 ASC, 1 DESC;