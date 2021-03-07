--Lecture

--Lab 1. T-SQL Creating variables - it always start with @

--Scalar functions
--(Променливата е клетка памет, на която даваме име)
DECLARE @Year SMALLINT = 2021; -- The variable will live only in this scope - when we close this window or disconnect from the SQL server, the variable will disappear. If we write like this 2021 - this is initial value of the variable. The initial value is not obligatory - we can write like this:
DECLARE @Year2 SMALLINT;
SELECT @Year -- returns 2021
SELECT @Year2  -- returns 0
--If we go to other connection or window, we can't select the variable there. The tables we can select - till we delete them. 
GO -- when we write it - all variables, declared before it will disapper (will stop existing).
--GO is a kind of a separator between two codes.
SELECT @Year  -- var @Year doesn't exist any more
--when we want to change the variable's value.
--Should run all three lines together:
DECLARE @Year SMALLINT = 2019;
SET @Year = @Year + 1 --
SELECT @Year
--We can declare a function's initial value to be a select function like this. But we should keep the data format to be equal. We make year to be varchar or something else, which is not convertable.
GO
DECLARE @Year SMALLINT = (SELECT COUNT(*) FROM [SoftUni].[dbo].[Employees])
SELECT @Year --293
GO
DECLARE @Year VARCHAR(MAX) = (SELECT TOP(1) FirstName FROM [SoftUni].[dbo].[Employees])
SELECT @Year --Guy
GO
DECLARE @Year SMALLINT = CONVERT(SMALLINT, '2008')
SELECT @Year --2008
GO
DECLARE @Year INT = CAST ('2011' AS INT)
SELECT @Year --2011
--Table-valued functions. The variable can be a table:
DECLARE @MyTempTable TABLE (Id INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50))
--Here we don't have an array for example, but we can create a table with 1 column instead of it.
INSERT INTO @MyTempTable VALUES ('Niki')
SELECT * FROM @MyTempTable

--Lab 2. Creating conditional statements 
--For create, update, delete, insert we use IF - ELSE, for select we use CASE - WHEN - returns value
--2.1 IF ((OR) AND) - first we check the first if, if it's not true, go to the else if - if not true, go to the next else if and so on till the else (like in CSharp)
--2.11 If - else if. Should run all 3 statements below:
DECLARE @YEAR3 SMALLINT = 0

IF DATEPART(Year, GETDATE()) = 2021 --YEAR(GETDATE())
	SET @YEAR3 = 2021 
ELSE IF DATEPART(Year, GETDATE()) = 2023
	SET @YEAR3 = 2023
ELSE
	SET @YEAR3 = -2000

SELECT @Year3
--2.12 If - else if + use BEGIN - END. Should run all 5 statements below:
DECLARE @YEAR4 SMALLINT = 0
DECLARE @MyTempTable2 TABLE (Id INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50))

IF DATEPART(Year, GETDATE()) = 2021 -- If we want more than 1 action - use BEGIN - END:
BEGIN
	SET @YEAR4 = 2021 
	INSERT INTO @MyTempTable2 VALUES ('2021') --It is declared already up
END
ELSE IF DATEPART(Year, GETDATE()) = 2023
	SET @YEAR4 = 2023
ELSE
	SET @YEAR4 = -2000

SELECT @Year4
SELECT * FROM @MyTempTable2

--2.2 CASE - WHEN - we use it when we make select
SELECT CASE @Year4
		WHEN 2020 THEN '2020'
		WHEN 2021 THEN '2021!!!'
		ELSE 'UnownYear'
	END
	
--Lab 3. Creating Loops - F5 FOR ALL 8 ROWS BELOW
--3.1 Without loop
DECLARE @Year5 SMALLINT = 2000

SELECT @Year5, COUNT(*) FROM [SoftUni].[dbo].[Employees] WHERE YEAR(HireDate) = @Year5 --NO need of GROUP BY as @Year5 is outer reference, like const

SET @Year5 = @Year5 + 1
SELECT @Year5, COUNT(*) FROM [SoftUni].[dbo].[Employees] WHERE YEAR(HireDate) = @Year5 
SET @Year5 = @Year5 + 1
SELECT @Year5, COUNT(*) FROM [SoftUni].[dbo].[Employees] WHERE YEAR(HireDate) = @Year5 
SET @Year5 = @Year5 + 1
SELECT @Year5, COUNT(*) FROM [SoftUni].[dbo].[Employees] WHERE YEAR(HireDate) = @Year5 
--3.2 With loop. We can insert in tables with loop too.
DECLARE @Year6 SMALLINT = 1997
WHILE (@Year6 <= 2008)
BEGIN
	SELECT @Year6, COUNT(*) FROM [SoftUni].[dbo].[Employees] WHERE YEAR(HireDate) = @Year6 
	SET @Year6 = @Year6 + 1 -- It can be SET @Year6 += 1, but not SET @Year6 ++
	IF @Year6 > 2005 --we can stop the loop this way, we can use CONTINUE too, but we should write it before some code to have some meaning
		BREAK
END
--RETURN - stops and exits the whole function
--BREAK - stops and exits the loop
--CONTINUE -- does't execute the rest of the code in the loop

--Lab 4. Functions like the methods in CSharp. They have parameters and a result (value or table). The views don't have parameters only result, the stored procedures can have more than 1 result. Functions are for small things, stored procedures for bigg one. There is no overloading for Functions like for methods. The names here we can write lower, upper as we like.

--User-defined functions cannot be used to perform actions that modify the database state: UPDATE, DELETE, INSERT

--dynamic SQL: a code which we want ot execute as a string i.e. we write the code using concatenation of strings:
DECLARE @TableName NVARCHAR(MAX) = '[SoftUni].[dbo].[Employees]'
EXEC('SELECT * FROM '+ @TableName)

--4.1 Scalar functions - a function returns a sing result.
--We don't use dynamic SQL and tmp tables in functions, we can use table variables as @MyTempTable2
--Example
--Build-in function
DECLARE @Base INT = 2
DECLARE @Exp INT = 30
DECLARE @Result INT = POWER(@Base,@Exp) --build-in function
SELECT @Result -- 1073741824
GO

DECLARE @Base INT = 2
DECLARE @Exp INT = 45
--DECLARE @Result BIGINT = POWER(@Base,@Exp) --POWER is INT - will throw an error
DECLARE @Result BIGINT = 1 --THE BIGGEST ONE IS: DECIMAL(38) i.e. 2^126 or 10^38-1
WHILE (@Exp > 0)
BEGIN 
	SET @Result = @Result * @Base
	SET @Exp -= 1
END
SELECT @Result -- 35184372088832 
GO

--User-defined function - this function below works correct only for @Base > 0 and @Exp > 0
USE SoftUni
CREATE FUNCTION udf_BigPower (@Base INT, @Exp INT)
--CREATE OR ALTER FUNCTION
RETURNS DECIMAL
AS
BEGIN 
	DECLARE @Result DECIMAL(38) = 1
	WHILE (@Exp > 0)
	BEGIN 
		SET @Result = @Result * @Base
		SET @Exp -= 1
	END
	RETURN @Result
END
--When we create it - it will be saved in the base we use in Programmability/ Funcions/ Scalar-valued Funcions. We should write dbo. when we select - otherwise it throws error
SELECT dbo.udf_BigPower(3,5) -- 243
SELECT TOP(5)
	FirstName, LastName, Salary, dbo.udf_BigPower(Salary, 2) AS Salary1
	--FirstName, LastName, Salary, dbo.udf_BigPower(Salary, DepartmentID) AS Salary2 -- it is too big to execute and throws exception
	FROM [SoftUni].[dbo].[Employees]

--4.2 Table-valued functions - it is like view but it has parameters. Returns a table as a result of a single SELECT statement or from table we have defined as a variable
CREATE OR ALTER FUNCTION udf_EmployeesByYear (@Year SMALLINT)
RETURNS TABLE
AS RETURN
	(SELECT * 
		FROM [SoftUni].[dbo].[Employees]
		WHERE YEAR(HireDate) = @Year)
--When we create it - it will be saved in the base we use in Programmability/ Funcions/ Table-valued Funcions. We should write dbo. when we select - otherwise it throws error.
SELECT *
	FROM dbo.udf_EmployeesByYear(2003)
--4.3 Multi-statement TVF --looks like the previous but returns table variable
CREATE OR ALTER FUNCTION udf_AllPowers (@MaxPower INT)
RETURNS @Table TABLE (Id INT IDENTITY PRIMARY KEY, Square BIGINT)
AS 
BEGIN 
	DECLARE @I INT = 1
	WHILE (@MaxPower >= @I)
	 BEGIN
		INSERT INTO @Table (Square) VALUES (@I * @I)
		SET @I = @I + 1
	 END
	 RETURN
END
--When we create it - it will be saved in the base we use in Programmability/ Funcions/ Table-valued Funcions. We should write dbo. when we select - otherwise it throws error.
SELECT * FROM dbo.udf_AllPowers(10) --1, 4, 9, 16...

SELECT * FROM dbo.udf_AllPowers(10)
	WHERE Square % 3 = 0 -- 9, 36, 81

--Lab 5. Salary Level Function
--Write a function ufn_GetSalaryLevel(@Salary MONEY) that receives salary of an employee and returns the level of the salary.
--If salary is < 30000 return "Low"
--If salary is between 30000 and 50000 (inclusive) returns "Average"
--If salary is > 50000 return "High"
--5.1 Mine
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
		IF @Salary IS NULL
			RETURN NULL

		DECLARE @SalaryLevel VARCHAR(10) 
		IF @Salary < 30000 
			SET @SalaryLevel = 'Low'
		ELSE IF @Salary BETWEEN 30000 AND 50000 
			SET @SalaryLevel = 'Average'
		ELSE IF @Salary > 50000 
			SET @SalaryLevel = 'High'
		RETURN @SalaryLevel
END

GO

SELECT FirstName, LastName, Salary,
	 dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
	FROM [SoftUni].[dbo].[Employees]

--5.1 Lab
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel2(@Salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
		IF @Salary IS NULL
			RETURN NULL

		IF @Salary < 30000 
			RETURN 'Low'
		ELSE IF @Salary <= 50000 
			RETURN 'Average'
		ELSE 
			RETURN 'High'

		RETURN NULL
END

GO 

SELECT FirstName, LastName, Salary,
	 dbo.ufn_GetSalaryLevel2(Salary) AS SalaryLevel --Why it cuts the to 4 symbols only??? The teacher didn't answer, although there was such a question...
	FROM [SoftUni].[dbo].[Employees]

--Lab 6. Stored Procedures - we execute them separately, functions are part of a code.
--Stored procedures are named sequences of T-SQL statements.
--Encapsulate repetitive program logic
--Can accept input parameters
--Can return output results

--When we create it - it will be saved in the base we use in Programmability/ Stored Procedures. There are system stored procedures like:
EXEC sp_monitor
EXEC sp_columns'Employees'--gives detailed info about the columns in a table
EXEC sp_addlogin 'Mari','maritest' -- will create user with password for this database
-- checks if the object references any object, and if other object references it.
EXEC sp_depends udf_AllPowers -- Object does not reference any object, and no objects reference it.
EXEC sp_depends 'Employees' -- shows many views and dbo.udf_EmployeesByYear are depending on it
--CREATE PROCEDURE ... AS ...GO -- no need of begin and end
--CREATE PROC ... AS ... GO -- no need of begin and end
--between AS and GO - we can have a lot of codes, not just one CRUD
--When we want a procedure to be executed we write 
--EXECUTE ... + params in ''
--EXEC ... + params in '', separated by comma
--ALTER PROC ... AS ...GO -- to change the procedure
--CREATE OR ALTER PROC ... AS ...GO
--DROP PROCEDURE + name - for deleting the procedure
--6.1 Procedure without parameters
USE SoftUni
CREATE OR ALTER PROC sp_RecreateProjects
AS
	INSERT INTO Projects ([Name], [Description], StartDate, EndDate)
		SELECT '[New]' +  [Name], [Description], StartDate, EndDate
			FROM [SoftUni].[dbo].[Projects]
GO

EXEC sp_RecreateProjects -- we have created 95 rows
--6.2 Procedure with parameters
--CREATE TABLE NamesWithSalaries
--( 
--	Id INT PRIMARY KEY IDENTITY,
--	FullName NVARCHAR(200) NOT NULL,
--	Salary MONEY NOT NULL
--)
--INSERT INTO NamesWithSalaries
--	SELECT CONCAT(FirstName,' ', LastName) AS FullName, Salary
--		FROM Employees
USE SoftUni
CREATE OR ALTER PROC sp_CreateNamesWithSalaries(@Count INT)
AS
	INSERT INTO NamesWithSalaries ([Full Name], Salary)
		SELECT TOP(@Count)
			'[New]' +  [Full Name], Salary
			FROM [SoftUni].[dbo].[NamesWithSalaries]
			ORDER BY Salary DESC
GO

EXEC sp_CreateNamesWithSalaries 3
--we can add default value for the parameter when we create the procedure like this 
--CREATE OR ALTER PROC sp_CreateNamesWithSalaries(@Count INT = 0)
CREATE OR ALTER PROC sp_CreateNamesWithSalaries
(@Count INT, @TextToAdd VARCHAR(MAX) = '[NewNew] ')
AS
	INSERT INTO NamesWithSalaries ([Full Name], Salary)
		SELECT TOP(@Count)
			@TextToAdd +  [Full Name], Salary
			FROM [SoftUni].[dbo].[NamesWithSalaries]
			ORDER BY Salary DESC
GO

EXEC sp_CreateNamesWithSalaries 3
EXEC sp_CreateNamesWithSalaries 1, '[Highest Salary] '--,,, if we have more parameters
EXEC sp_CreateNamesWithSalaries --diff order for params
	@TextToAdd = '[Highest Salary] ',
	@Count = 2

--6.3 Returning Multiple Results
--6.31
CREATE PROC sp_TwoSelects
AS
	SELECT COUNT(*) AS EmployeesCount FROM Employees
	SELECT COUNT(*) AS AddressesCount FROM Addresses
GO

EXEC sp_TwoSelects

--6.32 Returning Values Using OUTPUT Parameters
CREATE OR ALTER PROC sp_AddAndMultiply 
		(@FirstNumber INT, @SecondNumber INT,
		@Sum INT OUTPUT, @Product INT OUTPUT)
AS
	SET @Sum = @FirstNumber + @SecondNumber
	SET @Product = @FirstNumber * @SecondNumber
GO

DECLARE @Sum INT
DECLARE @Prod INT

EXEC sp_AddAndMultiply 2, 3, @Sum OUTPUT, @Prod OUTPUT

SELECT @Sum AS Sum, @Prod AS Prod-- 5 and 6

--Lab 7. Error Handling
USE SoftUni
--no error
CREATE OR ALTER FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF @StartDate IS NULL 
		RETURN 0
	IF @EndDate IS NULL
		RETURN 0
	RETURN DATEDIFF(Hour, @EndDate, @StartDate)
END

GO 

SELECT [Name], StartDate, EndDate, 
		dbo.udf_HoursToComplete(EndDate, StartDate) AS Diff
	FROM [SoftUni].[dbo].[Projects]

--7.1 Throwing exception
CREATE OR ALTER PROC sp_AddEmployeeToProjest(@EmployeeId INT, @ProjectId INT)
AS
--BEGIN
	--check (not full one, just for the example)
	DECLARE @CountEmployeeProject INT = 
		(SELECT COUNT(*) 
			FROM EmployeesProjects 
			WHERE EmployeeId = @EmployeeId AND ProjectId = @ProjectId)
	IF @CountEmployeeProject > 0
		THROW 50001, 'This Employee is already in the project!', 1 
	--inserting data
	INSERT INTO EmployeesProjects VALUES (@EmployeeId, @ProjectId)
--END
GO

EXEC sp_AddEmployeeToProjest 1, 104

--7.2 Exception handling

BEGIN TRY
	SELECT 1/ 0
END TRY

BEGIN CATCH
	SELECT 'Error!', @@ERROR, ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_LINE(), ERROR_PROCEDURE(), ERROR_STATE(), ERROR_SEVERITY()
END CATCH

--Lab 8. Employees with Three Projects
--Create a procedure that assigns projects to an employee. If the employee has more than 3 projects, throw an exception 
CREATE OR ALTER PROC udp_AssignProject (@EmployeeId INT, @ProjectId INT)
AS
	DECLARE @EmployeeProjects INT = 0
	SET @EmployeeProjects =
		(SELECT COUNT(ProjectId) 
			FROM EmployeesProjects
			WHERE EmployeeId = @EmployeeId)
	IF @EmployeeProjects >= 3
		THROW 50001, 'The employee has 3 or more projects!', 1

	DECLARE @CountEmployeeProject INT = 
	(SELECT COUNT(*) 
		FROM EmployeesProjects 
		WHERE EmployeeId = @EmployeeId AND ProjectId = @ProjectId)
	IF @CountEmployeeProject >= 1
		THROW 50002, 'This Employee is already in the project!', 1 
	INSERT INTO EmployeesProjects VALUES (@EmployeeId, @ProjectId)
GO

EXEC udp_AssignProject 1, 1 --The employee has 3 or more projects!
EXEC udp_AssignProject 2, 1 
EXEC udp_AssignProject 2, 2
EXEC udp_AssignProject 2, 3 
EXEC udp_AssignProject 2, 4 --The employee has 3 or more projects!
EXEC udp_AssignProject 6, 1
EXEC udp_AssignProject 6, 1 --This Employee is already in the project!

--Exercises
--Queries for SoftUni Database
--Ex 1.	Employees with Salary Above 35000
--Create stored procedure usp_GetEmployeesSalaryAbove35000 that returns all employees’ first and last names for whose salary is above 35000.
USE SoftUni
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS 
	SELECT FirstName, LastName
		FROM Employees
		WHERE Salary > 35000
GO
--GO and EXEC - don't submit in Judge!
EXEC usp_GetEmployeesSalaryAbove35000

--Ex 2.	Employees with Salary Above Number
--Create stored procedure usp_GetEmployeesSalaryAboveNumber that accept a number (of type DECIMAL(18,4)) as parameter and returns all employees’ first and last names whose salary is above or equal to the given number. 
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18,4))
AS 
	SELECT FirstName, LastName
		FROM Employees
		WHERE Salary >= @Number
GO
EXEC usp_GetEmployeesSalaryAboveNumber 55000.00

--Ex 3. Town Names Starting With
--Write a stored procedure usp_GetTownsStartingWith that accept string as parameter and returns all town names starting with that string. 
CREATE PROC usp_GetTownsStartingWith (@NameStart NVARCHAR(50))
AS
	SELECT [Name]
		FROM Towns
		WHERE [Name] LIKE @NameStart + '%'
GO

EXEC usp_GetTownsStartingWith 'S'

--Ex 4.	Employees from Town
--Write a stored procedure usp_GetEmployeesFromTown that accepts town name as parameter and return the employees’ first and last name that live in the given town. 
CREATE PROC usp_GetEmployeesFromTown (@InputTown NVARCHAR(200))
AS
	SELECT e.FirstName, e.LastName 
		FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID = t.TownID
	WHERE t.Name = @InputTown
--GO
EXEC usp_GetEmployeesFromTown 'Sofia'

--Ex 5.	Salary Level Function
--Write a function ufn_GetSalaryLevel(@salary DECIMAL(18,4)) that receives salary of an employee and returns the level of the salary.
--If salary is < 30000 return "Low"
--If salary is between 30000 and 50000 (inclusive) return "Average"
--If salary is > 50000 return "High"

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS 
BEGIN
	DECLARE @SalaryLevel VARCHAR(10)
	IF @salary < 30000 
		SET @SalaryLevel = 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000 
		SET @SalaryLevel = 'Average'
	ELSE IF @salary > 50000 
		SET @SalaryLevel = 'High'
	RETURN @SalaryLevel
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
	FROM Employees
--Ex 6.	Employees by Salary Level
--Write a stored procedure usp_EmployeesBySalaryLevel that receive as parameter level of salary (low, average or high) and print the names of all employees that have given level of salary. You should use the function - "dbo.ufn_GetSalaryLevel(@Salary) ", which was part of the previous task, inside your "CREATE PROCEDURE …" query.
CREATE PROC usp_EmployeesBySalaryLevel(@SalaryLevel VARCHAR(20))
AS
	SELECT FirstName, LastName
		FROM Employees
		WHERE  dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
GO

EXEC usp_EmployeesBySalaryLevel 'High'

--Ex 7.	Define Function
--Define a function ufn_IsWordComprised(@setOfLetters, @word) that returns true or false depending on that if the word is a comprised of the given set of letters. 
CREATE FUNCTION ufn_IsWordComprised
	(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
	DECLARE @Count SMALLINT = 1
	WHILE(LEN(@word) >= @Count)
		BEGIN
			DECLARE @CurrentLetter CHAR(1) = SUBSTRING(@word,@Count,1)
			IF CHARINDEX(@CurrentLetter, @setOfLetters) = 0
				RETURN 0
			SET @Count = @Count + 1
		END
	RETURN 1
END

SELECT dbo.ufn_IsWordComprised ('oistmiahf','Sofia')
SELECT dbo.ufn_IsWordComprised ('oistmiahf','halves')
--Ex 8. *Delete Employees and Departments
--Write a procedure with the name usp_DeleteEmployeesFromDepartment (@departmentId INT) which deletes all Employees from a given department. Delete these departments from the Departments table too. Finally SELECT the number of employees from the given department. If the delete statements are correct the select query should return 0.
--After completing that exercise restore your database to revert all changes.
--Hint:
--You may set ManagerID column in Departments table to nullable (using query "ALTER TABLE …").
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment
	(@departmentId INT)
AS 
	ALTER TABLE Departments
	ALTER COLUMN  ManagerId INT NULL

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN 
	(SELECT EmployeeID FROM Employees WHERE departmentId = @departmentId)

	UPDATE Employees
		SET ManagerID = NULL
	WHERE EmployeeID IN 
		(SELECT EmployeeID FROM Employees WHERE departmentId = @departmentId)

	UPDATE Employees
		SET ManagerID = NULL
	WHERE ManagerID IN 
		(SELECT EmployeeID FROM Employees WHERE departmentId = @departmentId)

	UPDATE Departments
		SET ManagerID = NULL
	WHERE departmentId = @departmentId
	
	DELETE FROM Employees
	WHERE departmentId = @departmentId

	DELETE FROM Departments
	WHERE departmentId = @departmentId

	SELECT COUNT(*) FROM Employees WHERE departmentId = @departmentId

GO
EXEC usp_DeleteEmployeesFromDepartment 1
	
--GO
--Queries for Bank Database
--Ex 9.	Find Full Name
--You are given a database schema with tables AccountHolders(Id (PK), FirstName, LastName, SSN) and Accounts(Id (PK), AccountHolderId (FK), Balance).  Write a stored procedure usp_GetHoldersFullName that selects the full names of all people.
USE Bank
CREATE PROCEDURE usp_GetHoldersFullName
AS 
	SELECT CONCAT(FirstName,' ', LastName) AS [Full Name]
		FROM [Bank].[dbo].[AccountHolders]
--GO
EXEC usp_GetHoldersFullName

--Ex 10. People with Balance Higher Than
--Your task is to create a stored procedure usp_GetHoldersWithBalanceHigherThan that accepts a number as a parameter and returns all people who have more money in total of all their accounts than the supplied number. Order them by first name, then by last name
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@BalanceInput MONEY)
AS
	SELECT FirstName, LastName
		FROM
			(SELECT FirstName, LastName, SUM(a.Balance) AS TotBalance
			FROM [Bank].[dbo].[AccountHolders] ah
			JOIN [Bank].[dbo].[Accounts] a ON ah.Id = a.AccountHolderId
			GROUP BY FirstName, LastName) AS tmp
	WHERE TotBalance > @BalanceInput
	ORDER BY FirstName, LastName
--DO
EXEC usp_GetHoldersWithBalanceHigherThan 560000

--Ex 11. Future Value Function
--Your task is to create a function ufn_CalculateFutureValue that accepts as parameters – sum (decimal), yearly interest rate (float) and number of years(int). It should calculate and return the future value of the initial sum rounded to the fourth digit after the decimal delimiter. Using the following formula:
--FV=I×((1+R)^T)
--	I – Initial sum
--	R – Yearly interest rate
--	T – Number of years
CREATE FUNCTION ufn_CalculateFutureValue 
(@I DECIMAL(18,4),@R FLOAT, @T INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @FV DECIMAL(18,4) = @I
	WHILE (@T > 0)
		BEGIN
			SET @FV = @FV * (1+@R)
			SET @T = @T - 1
		END
	RETURN @FV
END

SELECT dbo.ufn_CalculateFutureValue(100, 0.1, 2)
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
--Ex 12. Calculating Interest
--Your task is to create a stored procedure usp_CalculateFutureValueForAccount that uses the function from the previous problem to give an interest to a person's account for 5 years, along with information about his/her account id, first name, last name and current balance as it is shown in the example below. It should take the AccountId and the interest rate as parameters. Again you are provided with “dbo.ufn_CalculateFutureValue” function which was part of the previous task.
USE Bank --???????????????????
CREATE PROCEDURE usp_CalculateFutureValueForAccount
		(@AccountId  INT, @R FLOAT)
AS
	SELECT a.Id AS [Account Id],
		ah.FirstName AS [First Name], 
		ah.LastName AS [Last Name], 
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @R, 5)
		AS [Balance in 5 years]
	FROM [Bank].[dbo].[AccountHolders] ah
	JOIN [Bank].[dbo].[Accounts] a ON ah.Id = a.AccountHolderId
	WHERE a.Id = @AccountId 
--DO
EXEC usp_CalculateFutureValueForAccount 1, 0.1

--Queries for Diablo Database

--Ex 13. *Scalar Function: Cash in User Games Odd Rows
--Create a function ufn_CashInUsersGames that sums the cash of odd rows. Rows must be ordered by cash in descending order. The function should take a game name as a parameter and return the result as table. Submit only your function in.
--Execute the function over the following game names, ordered exactly like: "Love in a mist".
USE Diablo --?
CREATE FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(100))
RETURNS TABLE
AS
RETURN
	(SELECT SUM(Cash) AS SumCash
		FROM
		(SELECT g.Id, ug.Cash, 
			DENSE_RANK() OVER (ORDER BY ug.Cash DESC) AS [RANK]
			FROM [Diablo].[dbo].[Games] AS g
			JOIN [Diablo].[dbo].[UsersGames] AS ug
				ON g.Id = ug.GameId
		WHERE g.[Name] = @GameName
		) AS tmp
		WHERE [RANK] % 2 = 1)

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')