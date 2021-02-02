--Lab 1. Build-in functions, function in functions examples, columns can be parameters for functions:
SELECT GETDATE() -- returns datetime type: 2021-01-31 19:02:04.693
SELECT DATEPART(YEAR,GETDATE()) -- returns int type: 2021
SELECT DATEPART(MONTH, GETDATE()) -- returns int type: 1
SELECT DATEPART(DAY,GETDATE()) -- returns int type: 31
USE SoftUni
SELECT TOP(1) FirstName, LastName, GETDATE() -- Guy Gilbert 2021-01-31 19:11:38.790
  FROM [SoftUni].[dbo].[Employees]

SELECT TOP(1) FirstName, LastName, LEFT(FirstName, 1) -- Guy Gilbert G
  FROM [SoftUni].[dbo].[Employees]

--Lab 2. Aggregate and Analytic functions:
SELECT DepartmentID, AVG(Salary), MIN(Salary)
  FROM [SoftUni].[dbo].[Employees]
  GROUP BY DepartmentID

SELECT FirstName, Salary, DepartmentID,
	PERCENTILE_CONT(0.5) --it takes the element which is in the middle (0.5/ 1), for dept 1 it is between Michael and Gail - AVG between their salary is 34400 i.e. MEDIAN
	WITHIN GROUP (ORDER BY Salary DESC) -- before above operation the salary is order desc 
	OVER (PARTITION BY DepartmentId) AS MedianCont -- and groping or partition is made on DepartmentId
  FROM [SoftUni].[dbo].[Employees]

--Terri		63500	1	34400
--Roberto	43300	1	34400
--Michael	36100	1	34400
--Gail		32700	1	34400
--Jossef	32700	1	34400
--Sharon	32700	1	34400
--Rob		29800	2	26900
--Ovidiu	28800	2	26900
--Janice	25000	2	26900
--Thierry	25000	2	26900
--....
SELECT FirstName, Salary, DepartmentID,
	PERCENTILE_CONT(0.1) --in top 10%
	WITHIN GROUP (ORDER BY Salary DESC) 
	OVER (PARTITION BY DepartmentId) AS MedianCont 
  FROM [SoftUni].[dbo].[Employees]

--Terri		63500	1	53400
--Roberto	43300	1	53400
--Michael	36100	1	53400
--Gail		32700	1	53400
--Jossef	32700	1	53400
--Sharon	32700	1	53400
--Rob		29800	2	29500
--Ovidiu	28800	2	29500
--Janice	25000	2	29500
--Thierry	25000	2	29500
--...

--Lab 3. 
--Ranking functions RANK, ROW_NUMBER, DENSE_RANK, NTILE (OVER)
--Rowset functions OPENDATASOURCE, OPENJSON, OPENXML, OPENROWSET
--Scalar functions 
--Lab 4. String Functions
--Concatenation 
SELECT FirstName + ' ' + LastName --when there is a NULL, it makes the result NULL too
    AS [Full Name]
  FROM [SoftUni].[dbo].[Employees]

SELECT CONCAT(FirstName,' ',MiddleName,' ', LastName) --when there is a NULL, it just ignores it, but it keep one interval more where it should stay
    AS [Full Name]
  FROM [SoftUni].[dbo].[Employees]

SELECT CONCAT_WS(' ',FirstName,MiddleName,LastName)--when there is a NULL, it just ignores it and it puts no more then 1 interval between the columns
    AS [Full Name]
  FROM [SoftUni].[dbo].[Employees]

--substring(String, StartIndex, length)   - StartIndex - always is starts with 1. 
--We ALWAYS start with 1 in databases 
SELECT FirstName, MiddleName, LastName, SUBSTRING(LastName,1,3)+'...' AS ShortFamilyName
  FROM [SoftUni].[dbo].[Employees] --it works only in the result from the query, but not in the basic table

--replays - it replaces the data only in the result from the query, but not in the basic table like it works with UPDATE. REPLACE(String, Pattern, Replacement)
SELECT FirstName, MiddleName, LastName, REPLACE(LastName,'Gil','***') AS ChangedFamilyName
  FROM [SoftUni].[dbo].[Employees] --it works only in the result from the query, but not in the basic table
SELECT FirstName, MiddleName, LastName, REPLACE(LastName,N'√ошо','***') AS ChangedFamilyName
  FROM [SoftUni].[dbo].[Employees] --when we work with cirillic we should put N before the data. it cames from NVARCHAR
SELECT FirstName, MiddleName, LastName, REPLACE(REPLACE(LastName,'Gil','***'),'Bro','***') AS FamilyName2
  FROM [SoftUni].[dbo].[Employees] 

--LTRIM & RTRIM  -- премахва невидимите символи, TRIM - remove spaces from both sides
SELECT FirstName, MiddleName, LTRIM(LastName), RTRIM(LastName), TRIM(LastName)
  FROM [SoftUni].[dbo].[Employees] 

--LEN - shows the length of a string -- it ignores spaces before anf after the word in the string
SELECT FirstName, LastName, LEN(LastName) AS LengthLastName --Guy Gilbert 7
  FROM [SoftUni].[dbo].[Employees] 

--DATALENGTH Ц gets the number of used bytes
SELECT FirstName, LastName, DATALENGTH(LastName) AS LengthLastName --Guy Gilbert 7
  FROM [SoftUni].[dbo].[Employees] 
  ORDER BY LengthLastName DESC
SELECT FirstName, LastName, DATALENGTH(LastName) AS LengthLastName --Guy Gilbert 7
  FROM [SoftUni].[dbo].[Employees] 
  ORDER BY DATALENGTH(LastName)

--LEFT & RIGHT -- like substring
SELECT FirstName, LastName, LEFT(LastName,4) AS ShortLastName1, RIGHT(LastName,4) AS ShortLastName1, SUBSTRING(LastName,1,4), SUBSTRING(LastName,LEN(LastName)-4+1,4)
  FROM [SoftUni].[dbo].[Employees]
--LEFT(LastName,4) = SUBSTRING(LastName,1,4)
--RIGHT(LastName,4) = SUBSTRING(LastName,LEN(LastName)-4+1,4)

--LOWER & UPPER --it makes every char LOWER or UPPER 
SELECT FirstName, LastName, LOWER(LastName) AS LowerLastName, UPPER(LastName) AS UpperLastName
  FROM [SoftUni].[dbo].[Employees]

--REVERSE(String) - seldom used
SELECT FirstName, LastName, REVERSE(LastName) AS ReverseLastName
  FROM [SoftUni].[dbo].[Employees]

--REPLICATE(String, Count)
SELECT FirstName, LastName, REPLICATE(LastName,3) AS LastNameNTimes, REPLICATE('*',LEN(LastName))
  FROM [SoftUni].[dbo].[Employees]

--FORMAT(Data, Format, Culture) - Culture is the local settings
SELECT CONCAT_WS(' ',FirstName,MiddleName,LastName),
	HireDate, --the format is ALWAYS in the database like this yyyy-MM-dd HH:mm:ss 
	--1998-07-31 00:00:00
	FORMAT(HireDate,'dd-MMMM-yyyy','bg-BG'), --31-юли-1998
	FORMAT(HireDate,'dd-MM-yyyy','bg-BG'), -- 31-07-1998
	FORMAT(HireDate,'dddd MM yyyy','bg-BG'), -- петък 07 1998,
	Salary, --12500.00
	FORMAT(Salary,'F3','bg-BG'), --12500,000 - but I have made my formats to be '.', not ','
	FORMAT(Salary,'C','bg-BG'), --12†500,00 лв.
	FORMAT(Salary,'F3','en-GB'), --12500.000
	FORMAT(0.12,'P','bg-BG') --12,00%
  FROM [SoftUni].[dbo].[Employees]

--CHARINDEX (Pattern, String, StartIndex)  --locates a specific pattern (substring) in a string
SELECT CHARINDEX('y G', CONCAT_WS(' ', FirstName,LastName), 1), --3 - this is the first place, which we have located. If we wanna search more, we should ask to start at 4, not 1
CONCAT_WS(' ', FirstName,LastName)
  FROM [SoftUni].[dbo].[Employees] --if it doesn't find it, returns 0

--!!!!!if we wanna count how many times we gonna find something:
SELECT LastName, (LEN(LastName) - LEN(REPLACE(LastName,N'e',''))) / LEN(N'e') as Count1
  FROM [SoftUni].[dbo].[Employees] 
  ORDER BY Count1 DESC

--STUFF(String, StartIndex, Length, Substring) - inserts a substring at a specific position
--Length is how chars we need to delete and then insert the substring - in our case 0:
SELECT STUFF(CONCAT_WS(' ', FirstName,LastName), 1, 0,'Mr./ Mrs. ') as FullName, 
CONCAT_WS(' ', FirstName,LastName)
  FROM [SoftUni].[dbo].[Employees]

--Make the first symbol lower, the last upper and the middle ones leave uchanged
SELECT LastName, LOWER(LEFT(LastName,1)) + SUBSTRING(LastName,2,LEN(LastName) - 1 - 1) + UPPER(RIGHT(LastName,1)) as ChangedLastName
  FROM [SoftUni].[dbo].[Employees]
  ORDER BY LEN(LastName)
--Lab 5. Obfuscate CC Numbers
--Our database contains credit card details for customers
--Provide a summary without revealing the serial numbers
USE Demo
--5.1 Mine
SELECT CustomerID, FirstName, LastName, CONCAT(LEFT(PaymentNumber,6),REPLICATE('*',LEN(PaymentNumber)-6))
		AS PaymentNumberHide
	FROM Customers 
--5.2 Presentation
CREATE VIEW V_PablicPaymentInfo AS
SELECT CustomerID, FirstName, LastName, LEFT(PaymentNumber,6) + '**********'
	FROM Customers 
--5.3 Teacher
CREATE VIEW V_PablicPaymentInfo AS
SELECT CustomerID, FirstName, LastName, LEFT(PaymentNumber,6) + REPLICATE('*',LEN(PaymentNumber)-6)
		AS PaymentNumberHide
	FROM Customers
--ISNULL(NULL,' ') - if it's NULL will replace with ' '  

--Lab 6. Math Functions
-- + - / *
SELECT 1 + 1 --2
SELECT 5 - 1 --4
SELECT 3 * 2 --6
-- / 
	-- we can't devide to 0
	-- if we devide two int numbers - the result will be int too
	-- if we devide two int numbers and want the result not to be int, we should make the divisor or the dividend to be decimal, floating, double or other but not int
SELECT 6 / 2 -- 3
SELECT 7 / 2 -- 3
SELECT 7.0 / 2 -- 3.5
SELECT 7 / 2.0 -- 3.5
SELECT (7 * 1.0) / 2 -- 3.5

--Division with reminders, % - returns the reminder
SELECT 7 % 2 -- 1
SELECT 8 % 3 -- 2

USE SoftUni
SELECT *, ManagerId / DepartmentID --result is INT
	FROM Employees
SELECT *, 1.0 * ManagerId / DepartmentID --result is not int, but float, double or decimal
	FROM Employees
SELECT *, CAST(ManagerId AS float)/ DepartmentID --result is not int, but float, double or decimal
	FROM Employees
SELECT 2 + 2 * 10 --22 
--We follow the math rule here as well: 1. (), 2. * /, 3. +-

--Example: find the area of triangles by the given side and height
SELECT *, A * H / 2.0 AS Area
  FROM [Demo].[dbo].[Triangles2]

SELECT *, 0.5 * A * H AS Area
  FROM [Demo].[dbo].[Triangles2]
--PI gets the value of Pi as a float (15 Цdigit precision)
SELECT PI() -- 3.14159265358979 (rounded)
--Modulus, ||, absolute value
SELECT ABS(-20) --20
SELECT ABS(30) --30
--Square root (the result will be float)
SELECT SQRT(36) -- 6
SELECT SQRT(37) -- 6.08276253029822
--Raise to power of two
SELECT SQUARE(5) --25
SELECT SQUARE(-6) --36
--Example: Line Length
--Find the length of a line by given coordinates of the end points
SELECT SQRT(SQUARE(ABS(X2 - X1)) + SQUARE(ABS(Y2 - Y1))) AS Length
  FROM [Demo].[dbo].[Lines]

SELECT SQRT(SQUARE(X2 - X1) + SQUARE(Y2 - Y1)) AS Length
  FROM [Demo].[dbo].[Lines]

--POWER Ц raises value to the desired exponent. ¬дигане на степен 
SELECT POWER(3,2) -- 9
SELECT POWER(2,3) -- 8
--ROUND Ц obtains the desired precision
SELECT ROUND(100.58963,2) --100.59
SELECT ROUND(100.58963,3) --100.59
SELECT ROUND(100.58963,4) --100.5896
SELECT ROUND(100.58963,0) --101
SELECT ROUND(1023.58963,-2) --1000

--FLOOR & CEILING Ц return the nearest integer
SELECT FLOOR(123.589) --123
SELECT CEILING(123.589) --124
--Problem: Pallets
--Calculate the required number of pallets to ship each item
--BoxCapacity specifies how many items can fit in one box
--PalletCapacity specifies how many boxes can fit in a pallet
SELECT [Name], Quantity, BoxCapacity, PalletCapacity, 
	CEILING( CEILING(Quantity * 1.0 / BoxCapacity) * 1.0 /PalletCapacity) AS NumberOfPallets
  FROM [Demo].[dbo].[Products]

--SIGN Ц returns 1, -1 or 0, depending on the value of the sign
SELECT SIGN(0) -- 0
SELECT SIGN(15) -- +1
SELECT SIGN(-56) -- -1 

--RAND Ц gets a random float value in the range [0, 1]
--If Seed is not specified, it will be assigned randomly
SELECT RAND() -- 0.543239306564105 --every time it gives diferent number between 0 and 1
SELECT RAND(5) -- 0.713666525097956 -- it is always this number for 5
SELECT RAND(1111111) -- 0.416872947197737 -- it is always this number for 1111111

--LOG10 - returns float
SELECT LOG10(1000) --the exponent is 3, i.e. 10^3
SELECT LOG10(10000000) --the exponent is 7, 10^7
SELECT LOG(64,2) --the exponent is 6, 2^6
SELECT LOG(27,3) --the exponent is 3, 3^3
--SIN - sinus
SELECT SIN(0) --0 --This is in radians, not in degrees
SELECT SIN(PI() / 2) -- 1
--COS - cosinus
SELECT COS(0) -- 1

--Lab 7. Date Functions
--DATEPART Ц extract a segment from a date as an integer
--Part can be any part and format of date or time
SELECT ProductName, OrderDate, 
	DATEPART(QUARTER, OrderDate) AS [Quarter],
	DATEPART(YEAR, OrderDate) AS [Year],
	YEAR(OrderDate) AS Year2,
	DATEPART(MONTH, OrderDate) AS [Month],
	MONTH(OrderDate) AS Month2,
	DATEPART(DAY, OrderDate) AS [Day],
	DAY(OrderDate) AS Day2,
	DATEPART(WEEK, OrderDate) AS [Week], --from 1 to 52 week of the year
	DATEPART(WEEKDAY, OrderDate) AS [Weekday], --from 1 (is Sunday) to 7 (is Saturday) - American style
	FORMAT(OrderDate, 'ddd') AS [Weekday], --from Monday to Sunday!!!!!!!!!!!
	DATEPART(DAYOFYEAR, OrderDate) AS [DayOfYear] --from 1 to 365/366
  FROM [Orders].[dbo].[Orders]

--Problem: Quarterly Report
--Prepare sales data for aggregation by displaying yearly quarter, month, year and day of sale
SELECT ProductName, OrderDate,--2016-09-19 00:00:00.000
	DATEPART(QUARTER, OrderDate) AS [Quarter],--3
	DATEPART(YEAR, OrderDate) AS [Year],--2016
	DATEPART(MONTH, OrderDate) AS [Month],--9
	DATEPART(DAY, OrderDate) AS [Day],--19
	CAST(DATEPART(YEAR, OrderDate) AS varchar)+ '/' + 
	CAST(DATEPART(MONTH, OrderDate) AS varchar) + '/' + 
	CAST(DATEPART(DAY, OrderDate) AS varchar)
	AS NewDate --2016/9/19
  FROM [Orders].[dbo].[Orders]

--DATEDIFF(Part, FirstDate, SecondDate) Ц finds the difference between two dates
--Part can be any part and format of date or time
SELECT *,GETDATE(), 
	DATEDIFF(DAY, OrderDate ,GETDATE()) AS DeliveryDelayDays, --The result is in days
	DATEDIFF(QUARTER, OrderDate ,GETDATE()) AS DeliveryDelayQuarters, --The result is in days
	DATEDIFF(YEAR, OrderDate ,GETDATE()) AS DeliveryDelayYears --The result is in years
  FROM [Orders].[dbo].[Orders]

--DATENAME(Part, Date) Ц gets a string representation of a date's part
SELECT FirstName, LastName, HireDate, 
		FORMAT(HireDate, 'dddd', 'bg-BG') AS YearHired2, --петък
		DATENAME(WEEKDAY, HireDate) AS YearHired2 --Friday - we can change the default settings of the computer like this SET LANGUAGE BULGARIAN / SET LANGUAGE ENGLISH
	 FROM [SoftUni].[dbo].[Employees]
	 
--DATEADD(Part, Number, Date) Ц performs date arithmetic
SELECT FirstName, LastName, HireDate, 
		DATEADD(WEEK, 2, HireDate) AS TwoWeeksAhead,
		DATEADD(DAY, 5, HireDate) AS FiveDaysAhead,
		DATEADD(YEAR, 7, HireDate) AS SevenYearsAhead
	 FROM [SoftUni].[dbo].[Employees]

--GETDATE Ц obtains the current date and time
SELECT GETDATE() --2021-02-01 21:47:23.403

--EOMONTH Ц returns the last day of the month
SELECT EOMONTH(GETDATE()) --2021-02-28
SELECT EOMONTH('2021-03-08') --2021-03-31

--Lab 8. Other Functions
--CAST(Data AS NewType)  & CONVERT(NewType, Data)  Ц conversion between data types
SELECT ProductName, OrderDate,--2016-09-19 00:00:00.000
	CAST(DATEPART(YEAR, OrderDate) AS varchar)+ '/' + 
	CAST(DATEPART(MONTH, OrderDate) AS varchar) + '/' + 
	CAST(DATEPART(DAY, OrderDate) AS varchar)
	AS NewDate --2016/9/19
  FROM [Orders].[dbo].[Orders]

--ISNULL(Data, DefaultValue) Ц swaps NULL values with a specified default value
SELECT FirstName, MiddleName, LastName, 
		CONCAT_WS(' ', FirstName, MiddleName, LastName) AS FullName1,--Roberto Tamburello
		CONCAT(FirstName,' ', ISNULL(MiddleName,''),' ', LastName) AS FullName2,
		--Roberto  Tamburello 
		FirstName + ' ' + MiddleName + ' ' + LastName AS FullName3, --NULL
		FirstName + ' ' + ISNULL(MiddleName,'') + ' ' + LastName AS FullName4 --Roberto  Tamburello - can't avoid ' ', but it doesn't make FullName2 NULL as it will be if we don't use ISNULL
	 FROM [SoftUni].[dbo].[Employees]

--COALESCE Ц evaluates the arguments in order and returns the current value of the first expression that initially does not evaluate to NULL. ISNULL(ISNULL(ISNULL(ISNULL(...
--or a??b??c??d in C# == COALESCE(a,b,c,d) here in DB, i.e. we take the first one which is not null and we use it
SELECT FirstName, MiddleName, LastName, 
	COALESCE(FirstName, MiddleName, LastName), --if the FirstName is null, take MiddleName, if the MiddleName is null too, take LastName
	COALESCE(MiddleName, LastName, FirstName)
	 FROM [SoftUni].[dbo].[Employees]

--OFFSET & FETCH Ц get only specific rows from the result set
--Used in combination with ORDER BY for pagination - в сайт например показна инфото във форум например в н€колко номерирани страници.
SELECT * 
	 FROM [SoftUni].[dbo].[Employees]
	 ORDER BY HireDate--SHOULD BE SORTED 
	 OFFSET 0 ROWS --THIS ONE IS EQUAL TO TOP(5)
	 FETCH NEXT 5 ROWS ONLY
SELECT *
	 FROM [SoftUni].[dbo].[Employees]
	 ORDER BY HireDate--SHOULD BE SORTED
	 OFFSET 5 ROWS
	 FETCH NEXT 5 ROWS ONLY
SELECT *
	 FROM [SoftUni].[dbo].[Employees]
	 ORDER BY HireDate--SHOULD BE SORTED
	 OFFSET 10 ROWS
	 FETCH NEXT 5 ROWS ONLY
--...

--Lab 9. Ranking Functions
--ROW_NUMBER Ц always generate unique values without any gaps, even if there are ties
--The numbering of the ordered list is done like this, that there is no matter if there are people with one and the same salary (one is 6-th and the other is 7-th for example, but both have 50500)
SELECT ROW_NUMBER() OVER (ORDER BY Salary DESC), Salary, FirstName, LastName, JobTitle
	 FROM [SoftUni].[dbo].[Employees]
	 ORDER BY Salary DESC

--RANK Ц can have gaps in its sequence and when values are the same, they get the same rank
--The numbering of the ordered list is done like this, that if there are people with one and the same salary they will be one and the same rank(one is 6-th and the other is 6-th for example too, both have 50500 and there is no 7-th rank in the list)
SELECT RANK() OVER (ORDER BY Salary DESC), Salary, FirstName, LastName, JobTitle
	 FROM [SoftUni].[dbo].[Employees]
	 ORDER BY Salary DESC

--DENSE_RANK Ц returns the same rank for ties, but it doesnТt    have any gaps in the sequence
--The numbering of the ordered list is done like this, that if there are people with one and the same salary they will be one and the same rank(one is 6-th and the other is 6-th for example too, both have 50500 and there is 7-th rank in the list)
--DENSE_RANK without PARTITION
SELECT 
		DENSE_RANK() OVER (ORDER BY Salary DESC) AS DENSE_RANK_Simple, 
		Salary, FirstName, LastName, JobTitle
	 FROM [SoftUni].[dbo].[Employees]
	 ORDER BY Salary DESC
--DENSE_RANK with PARTITION
SELECT 
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID)  AS DENSE_RANK_With_Partition,
		EmployeeID, Salary, FirstName, LastName, JobTitle
	 FROM [SoftUni].[dbo].[Employees]
	 ORDER BY Salary DESC

--NTILE Ц Distributes the rows in an ordered partition into a specified number of groups
SELECT NTILE(2) OVER (ORDER BY Salary DESC), --2 shows the number of piles we split all
		Salary, FirstName, LastName, JobTitle
	 FROM [SoftUni].[dbo].[Employees]
	 ORDER BY Salary DESC

SELECT NTILE(100) OVER (ORDER BY Salary DESC), Salary, FirstName, LastName, JobTitle
	 FROM [SoftUni].[dbo].[Employees]
	 ORDER BY JobTitle DESC

--Compare the upper ranks:
SELECT 
		ROW_NUMBER() OVER (ORDER BY Salary DESC) AS ROW_NUMBER, 
		RANK() OVER (ORDER BY Salary DESC) AS RANK, 
		DENSE_RANK() OVER (ORDER BY Salary DESC) AS DENSE_RANK,
		NTILE(2) OVER (ORDER BY Salary DESC) AS NTILE,
		Salary, FirstName, LastName, JobTitle
	 FROM [SoftUni].[dbo].[Employees]
	 ORDER BY Salary DESC

--Lab 10. Wildcards (when we write in where) - Selecting Results by Partial Match
--Using WHERE Е LIKE 
--We use wildcard characters: %, _ , [...], [^...]
SELECT *
	 FROM [SoftUni].[dbo].[Employees]
	 WHERE JobTitle LIKE 'Chief%' -- starting with Chief: Chief Executive Officer, Chief Financial Officer
SELECT *
	 FROM [SoftUni].[dbo].[Employees]
	 WHERE JobTitle LIKE '%Manager' -- ending with Manager
SELECT *
	 FROM [SoftUni].[dbo].[Employees]
	 WHERE JobTitle LIKE 'E%Manager' -- starts with E, something else and ending with Manager
SELECT *
	 FROM [SoftUni].[dbo].[Employees]
	 WHERE JobTitle LIKE '%Ma%' -- contains Ma
SELECT *
	 FROM [SoftUni].[dbo].[Employees]
	 WHERE JobTitle LIKE '%Manage_'-- meaning of _ is that there is only one symbol after Manager
SELECT *
	 FROM [SoftUni].[dbo].[Employees]
	 WHERE JobTitle LIKE '[EMA]%Manager'-- everything which starts with E, M or A [EMA]
SELECT *
	 FROM [SoftUni].[dbo].[Employees]
	 WHERE JobTitle LIKE '[^EMA]%Manager'-- everything which doesn't starts with E, M or A [EMA]

--ESCAPE Ц specify a prefix to treat special characters as normal
SELECT *
	 FROM [SoftUni].[dbo].[Employees]
	 WHERE JobTitle LIKE '[^EMA]%Man_ger' ESCAPE '_' -- here '_' is used as symbol


--Exercises - IN JUDGE - TABLES IN THE QUERIES SHOULD BE ONLY WITH THEIR NAMES, NOT WITH DATABASE AND SCHEMAS  

--Part I Ц Queries for SoftUni Database
--Ex 1. Find Names of All Employees by First Name
--Write a SQL query to find first and last names of all employees whose first name starts with "SA". 
USE SoftUni
SELECT FirstName, LastName 
	FROM [SoftUni].[dbo].[Employees]
	WHERE LEFT(FirstName,2) = 'SA'

--Ex 2. Find Names of All employees by Last Name 
--Write a SQL query to find first and last names of all employees whose last name contains "ei".
SELECT FirstName, LastName 
	FROM [SoftUni].[dbo].[Employees]
	WHERE LastName LIKE '%ei%'

--Ex 3. Find First Names of All Employees
--Write a SQL query to find the first names of all employees in the departments with ID 3 or 10 and whose hire year is between 1995 and 2005 inclusive.
SELECT FirstName
	FROM [SoftUni].[dbo].[Employees]
	WHERE DepartmentID IN (3, 10) 
		AND DATEPART(YEAR,HireDate) BETWEEN 1995 AND 2005

--Ex 4. Find All Employees Except Engineers
--Write a SQL query to find the first and last names of all employees whose job titles does not contain "engineer". 
SELECT FirstName, LastName
	FROM [SoftUni].[dbo].[Employees]
	WHERE JobTitle NOT LIKE '%engineer%' 

--Ex 5. Find Towns with Name Length
--Write a SQL query to find town names that are 5 or 6 symbols long and order them alphabetically by town name. --
SELECT [Name]
	FROM [SoftUni].[dbo].[Towns]
	WHERE LEN([Name]) IN (5,6)
	ORDER BY [Name]

--Ex 6. Find Towns Starting With
--Write a SQL query to find all towns that start with letters M, K, B or E. Order them alphabetically by town name. 
SELECT TownID, [Name]
	FROM [SoftUni].[dbo].[Towns]
	WHERE LEFT([Name],1) IN ('M','K','B','E')
	ORDER BY [Name]
	
--Ex 7. Find Towns Not Starting With
--Write a SQL query to find all towns that does not start with letters R, B or D. Order them alphabetically by name. 
SELECT TownID, [Name]
	FROM [SoftUni].[dbo].[Towns]
	WHERE LEFT([Name],1) NOT IN ('R','B','D')
	ORDER BY [Name]	

--Ex 8. Create View Employees Hired After 2000 Year
--Write a SQL query to create view V_EmployeesHiredAfter2000 with first and last name to all employees hired after 2000 year.
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
	FROM [SoftUni].[dbo].[Employees]
	WHERE DATEPART(YEAR, HireDate) > 2000

--Ex 9. Length of Last Name
--Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
SELECT FirstName, LastName
	FROM [SoftUni].[dbo].[Employees]
	WHERE LEN(LastName) = 5

--Ex 10. Rank Employees by Salary
--Write a query that ranks all employees using DENSE_RANK. In the DENSE_RANK function, employees need to be partitioned by Salary and ordered by EmployeeID. You need to find only the employees whose Salary is between 10000 and 50000 and order them by Salary in descending order.
SELECT EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [RANK] 
	FROM [SoftUni].[dbo].[Employees]
	WHERE Salary BETWEEN 10000 and 50000
	ORDER BY Salary DESC

--Ex 11. Find All Employees with Rank 2 *
--Use the query from the previous problem and upgrade it, so that it finds only the employees whose Rank is 2 and again, order them by Salary (descending).

WITH NewShortTableEmployees AS
(SELECT TOP(293) EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [RANK] 
	FROM [SoftUni].[dbo].[Employees]
	WHERE Salary BETWEEN 10000 and 50000
	ORDER BY Salary DESC)
SELECT *
	FROM NewShortTableEmployees
	WHERE [RANK] = 2
	ORDER BY Salary DESC

--Part II Ц Queries for Geography Database 

--Ex 12. Countries Holding СAТ 3 or More Times
--Find all countries that holds the letter 'A' in their name at least 3 times (case insensitively), sorted by ISO code. Display the country name and ISO code. 
--USE Geography
SELECT CountryName, IsoCode
  FROM [Geography].[dbo].[Countries]
  WHERE CountryName LIKE '%A%A%A%'
  ORDER BY IsoCode

--Ex 13. Mix of Peak and River Names
--Combine all peak names with all river names, so that the last letter of each peak name is the same as the first letter of its corresponding river name. Display the peak names, river names, and the obtained mix (mix should be in lowercase). Sort the results by the obtained mix.
SELECT p.PeakName, r.RiverName, 
		LOWER(CONCAT(p.PeakName, SUBSTRING(r.RiverName,2, LEN(r.RiverName) -1))) AS Mix
	FROM [Geography].[dbo].[Peaks] AS p
	JOIN [Geography].[dbo].[Rivers] AS r ON RIGHT(p.PeakName,1) = LEFT(r.RiverName,1)
	ORDER BY Mix

--Part III Ц Queries for Diablo Database

--Ex 14. Games from 2011 and 2012 year
--Find the top 50 games ordered by start date, then by name of the game. Display only games from 2011 and 2012 year. Display start date in the format "yyyy-MM-dd". 
SELECT TOP (50) [Name], FORMAT([Start], 'yyyy-MM-dd', 'bg-BG') AS [Start]
  FROM [Diablo].[dbo].[Games]
  WHERE DATEPART(YEAR,[Start]) IN (2011,2012)
  ORDER BY [Start], [Name]

--Ex 15. User Email Providers
--Find all users along with information about their email providers. Display the username and email provider. Sort the results by email provider alphabetically, then by username. 
SELECT Username, 
	SUBSTRING(Email, CHARINDEX ('@', Email, 1) + 1, LEN(Email) - CHARINDEX ('@', Email, 1)) 
	AS [Email Provider]
  FROM [Diablo].[dbo].[Users]
  ORDER BY [Email Provider], Username

--Ex 16. Get Users with IPAdress Like Pattern
--Find all users along with their IP addresses sorted by username alphabetically. Display only rows that IP address matches the pattern: "***.1^.^.***".
--Legend: * - one symbol, ^ - one or more symbols
SELECT Username, IpAddress
  FROM [Diablo].[dbo].[Users]
  WHERE IpAddress LIKE '___.1%.%.___'
  ORDER BY Username

--Ex 17. Show All Games with Duration and Part of the Day
--Find all games with part of the day and duration sorted by game name alphabetically then by duration (alphabetically, not by the timespan) and part of the day (all ascending). Parts of the day should be Morning (time is >= 0 and < 12), Afternoon (time is >= 12 and < 18), Evening (time is >= 18 and < 24). Duration should be Extra Short (smaller or equal to 3), Short (between 4 and 6 including), Long (greater than 6) and Extra Long (without duration). 
SELECT [Name],
	CASE 
		WHEN (DATEPART(Hour, Start) * 60 * 60  + DATEPART(Minute,Start) * 60 + DATEPART(Second, Start) >= 0 AND  DATEPART(Hour, Start) * 60 * 60  + DATEPART(Minute,Start) * 60 + DATEPART(Second, Start) < 12 * 60 * 60)
			THEN 'Morning'
		WHEN (DATEPART(Hour, Start) * 60 * 60  + DATEPART(Minute,Start) * 60 + DATEPART(Second, Start) >= 12 * 60 * 60 AND  DATEPART(Hour, Start) * 60 * 60  + DATEPART(Minute,Start) * 60 + DATEPART(Second, Start) < 18 *	 60 * 60)
			THEN 'Afternoon'
		WHEN (DATEPART(Hour, Start) * 60 * 60  + DATEPART(Minute,Start) * 60 + DATEPART(Second, Start) >= 18 * 60 * 60 AND  DATEPART(Hour, Start) * 60 * 60  + DATEPART(Minute,Start) * 60 + DATEPART(Second, Start) < 24 *	 60 * 60)
			THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration IS NULL THEN 'Extra Long'
		ELSE
			CASE
				WHEN Duration <= 3 THEN 'Extra Short'
				WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
				WHEN Duration > 6 THEN 'Long'
			END 
	END AS Duration
  FROM [Diablo].[dbo].[Games]
  ORDER BY [Name] ASC, Duration ASC, [Part of the Day] ASC

--Part IV Ц Date Functions Queries

--Ex 18. Orders Table
--You are given a table Orders(Id, ProductName, OrderDate) filled with data. Consider that the payment for that order must be accomplished within 3 days after the order date. Also the delivery date is up to 1 month. Write a query to show each productТs name, order date, pay and deliver due dates. 
SELECT ProductName, OrderDate,
	DATEADD(DAY, 3, OrderDate) AS [Pay Due], 
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
	FROM [Orders].[dbo].[Orders]