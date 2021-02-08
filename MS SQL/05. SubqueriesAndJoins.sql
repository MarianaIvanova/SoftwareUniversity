--Lab 1. Joins
SELECT * --e.FirstName, e.LastName, a.AddressText, t.Name AS Town
  FROM [SoftUni].[dbo].[Employees] e-- LEFT 
  JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID
  JOIN [SoftUni].[dbo].[Towns] t ON a.TownID = t.TownID
  --WHERE [Name] = 'Sofia'
ORDER BY Salary DESC

--inner join
SELECT e.FirstName, e.LastName, a.AddressText
  FROM [SoftUni].[dbo].[Employees] e
  JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID
  --INNER JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID
--the same can be done with following, but we use the upper one for join:
SELECT e.FirstName, e.LastName, a.AddressText
  FROM [SoftUni].[dbo].[Employees] e,[SoftUni].[dbo].[Addresses] a
  WHERE a.AddressID = e.AddressID

--left (outer) join
SELECT *
  FROM [SoftUni].[dbo].[Employees] e 
  LEFT JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID
  --LEFT OUTER JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID

--right (outer) join
SELECT * 
  FROM [SoftUni].[dbo].[Employees] e 
  RIGHT JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID--see row 159
  --RIGHT OUTER JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID
SELECT * 
  FROM [SoftUni].[dbo].[Employees] e
  RIGHT JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID

--full outer join
SELECT * 
  FROM [SoftUni].[dbo].[Employees] e
  FULL JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID
  --FULL OUTER JOIN [SoftUni].[dbo].[Addresses] a ON a.AddressID = e.AddressID

--cross joins: Cartesian product - т.нар. в математиката ƒекартово произведение Ц взема всеки с всеки
SELECT * 
  FROM [SoftUni].[dbo].[Employees] AS e, [SoftUni].[dbo].[Addresses] AS a
--or it can be written like this
SELECT * 
  FROM [SoftUni].[dbo].[Employees] AS e
  CROSS JOIN [SoftUni].[dbo].[Addresses] AS a
--or if we wanna see the longest distance between the cities, we should see the distance between all two pairs of cities --(without compairing with itself) or see the longest name if we concat them...
SELECT *
  FROM [SoftUni].[dbo].[Towns] AS t1, [SoftUni].[dbo].[Towns] AS t2
 --WHERE t1.TownID != t2.TownID
 --ORDER BY LEN(t1.Name) + LEN(t2.Name) DESC 

 --Lab 2. Addresses with Towns
--Display address information of all employees in "SoftUni" database. Select first 50 employees. A query that selects: FirstName, LastName, Town and AddressText. Order them by FirstName, then by LastName (ascending). Hint: Use three-way join. 
SELECT TOP(50) e.FirstName, e.LastName, t.Name AS Town, a.AddressText
	FROM [SoftUni].[dbo].[Employees] e
	LEFT JOIN [SoftUni].[dbo].[Addresses] a ON e.AddressID = a.AddressID
	LEFT JOIN [SoftUni].[dbo].[Towns] t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName
--If we have more than 1 join and wanna use LEFT/RIGHT JOIN, we should use LEFT on both of the JOINs, cause the first two table make a new table which we connect with the third one, so we need to use LEFT/RIGHT again

--Lab 3.  Use "SoftUni" database. Write a query that selects: EmployeeID, FirstName, LastName, DepartmentName. Sorted by EmployeeID in ascending order. Select only employees from "Sales" department.
SELECT  e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS DepartmentName
	FROM [SoftUni].[dbo].[Employees] e
		JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
	WHERE  d.[Name] = 'Sales'
	ORDER BY EmployeeID

--Lab 4. Employees Hired After
--Write a query that selects: FirstName. LastName, HireDate, DeptName. Filter only employees hired after 1.1.1999 and are from either "Sales" or "Finance" departments, sorted by HireDate (ascending).
SELECT  e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName
	FROM [SoftUni].[dbo].[Employees] e
	JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] IN ('Sales','Finance')
		--AND e.HireDate >= '1999-01-01' --this is the format most of the databases use!!!
		AND FORMAT(e.HireDate, 'yyyy-MM-dd','bg-BG') >= '1999-01-01'
		ORDER BY HireDate
--Lab 5. Join a table with itself
SELECT  *--e.EmployeeID, e.FirstName, e.LastName
	FROM [SoftUni].[dbo].[Employees] e
		LEFT JOIN [SoftUni].[dbo].[Employees] m ON e.ManagerID = m.EmployeeID
		LEFT JOIN [SoftUni].[dbo].[Employees] m2 ON m.ManagerID = m2.EmployeeID
ORDER BY e.EmployeeID

--Lab 6. Employee Summary
--Display information about employee's manager and employee's department. Show only the first 50 employees. Sort by EmployeeID (ascending). Show only EmployeeId, EmployeeName (FirstName and LastName), ManagerName (FirstName and LastName), DepartmentName
SELECT TOP(50) e.EmployeeId, 
		CONCAT(e.FirstName,' ', e.LastName) AS EmployeeName,
		CONCAT(m.FirstName,' ', m.LastName) AS ManagerName,
		d.Name AS DepartmentName
	FROM [SoftUni].[dbo].[Employees] e
		LEFT JOIN [SoftUni].[dbo].[Employees] m ON e.ManagerID = m.EmployeeID
		LEFT JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
	ORDER BY EmployeeID

--Lab 7.Subqueries
--7.1
SELECT  e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName,
	(SELECT COUNT(*) FROM [SoftUni].[dbo].[Employees] WHERE DepartmentID =  d.DepartmentID)
	AS EmployeesInDepartment	--subquery
	FROM [SoftUni].[dbo].[Employees] e
	JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] IN (SELECT Name FROM [SoftUni].[dbo].[Departments] WHERE NAME LIKE 'P%') 
	--subquery
		AND e.HireDate >= (SELECT MIN(HireDate) FROM [SoftUni].[dbo].[Employees]) --'1999-01-01'--subquery 
		ORDER BY HireDate
--7.2
SELECT * FROM
(SELECT  FirstName, LastName FROM [SoftUni].[dbo].[Employees]) AS e

--Lab 8. Min Average Salary
--Write a query that returns the value of the lowest average salary of all departments.
--Display lowest average salary of all departments. Calculate average salary for each department. Then show the value of smallest one.
--8.1
SELECT MIN(AVGSalaryDept) MinAverageSalary 
	FROM
	(SELECT DepartmentID, AVG(Salary) AS AVGSalaryDept
		FROM [SoftUni].[dbo].[Employees] 
	GROUP BY DepartmentID) AS a
--8.2
SELECT MIN(AVGSalaryDept) MinAverageSalary FROM
	(SELECT d.DepartmentID,
		(SELECT AVG(Salary) 
			FROM [SoftUni].[dbo].[Employees] 
			WHERE DepartmentID = d.DepartmentID) AS AVGSalaryDept
	FROM [SoftUni].[dbo].[Departments] d) AS AVGSalaryDept

--Lab 9. Common Table Expressions (CTE)
--This is the query from 7.1 - but using CTE
WITH CTE_Empl AS 
	(SELECT  e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName,
		(SELECT COUNT(*) FROM [SoftUni].[dbo].[Employees] WHERE DepartmentID =  d.DepartmentID)
		AS EmployeesInDepartment	--subquery
		FROM [SoftUni].[dbo].[Employees] e
		JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
		WHERE d.[Name] IN (SELECT Name FROM [SoftUni].[dbo].[Departments] WHERE NAME LIKE 'P%') 
		--subquery
			AND e.HireDate >= (SELECT MIN(HireDate) FROM [SoftUni].[dbo].[Employees]) --'1999-01-01'--subquery 
	) 
SELECT * FROM CTE_Empl
ORDER BY HireDate

--Lab 10. Temporary Tables 
--use # before the name of the table, this way DB recognizes its type. It disappears when we disconnect with the DB (CREATE TABLE #t)
--when we use ## - when all the people using the SQL server are disconnected (CREATE TABLE ##t)
--Table variables (DECLARE @t TABLE) 
--Tempdb permanent tables (USE tempdb CREATE TABLE t)
CREATE TABLE #Tmp
(
	--we can make everything we want here
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL
)


--Exercises:
--USE DB SoftUni
--Ex 1. Write a query that selects: EmployeeId, JobTitle, AddressId, AddressText.Return the first 5 rows sorted by AddressId in ascending order.
SELECT  TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
	FROM [SoftUni].[dbo].[Employees] e
	JOIN [SoftUni].[dbo].[Addresses] a ON e.AddressID = a.AddressID
ORDER BY AddressId
--Ex 2. See Lab 2
--Ex 3. See Lab 3
--Ex 4.	Employee Departments
--Write a query that selects: EmployeeID, FirstName, Salary, DepartmentName. Filter only employees with salary higher than 15000. Return the first 5 rows sorted by DepartmentID in ascending order.
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS DepartmentName
	FROM [SoftUni].[dbo].[Employees] e
	JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
	WHERE   e.Salary > 15000
	ORDER BY d.DepartmentID

--Ex 5. Employees Without Project
--Write a query that selects: EmployeeID, FirstName. Filter only employees without a project. Return the first 3 rows sorted by EmployeeID in ascending order.
SELECT TOP (3) e.EmployeeID, e.FirstName
	FROM [SoftUni].[dbo].[Employees] e
	LEFT JOIN [SoftUni].[dbo].[EmployeesProjects] ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.EmployeeID IS NULL
	ORDER BY ep.EmployeeID 

--Ex 6. See Lab 4
--Ex 7. Employees with Project
--Write a query that selects: EmployeeID, FirstName and ProjectName Filter only employees with a project which has started after 13.08.2002 and it is still ongoing (no end date). Return the first 5 rows sorted by EmployeeID in ascending order.
SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name]  AS ProjectName
	FROM [SoftUni].[dbo].[Employees] e
		LEFT JOIN [SoftUni].[dbo].[EmployeesProjects] ep ON e.EmployeeID = ep.EmployeeID
		LEFT JOIN [SoftUni].[dbo].[Projects] p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL --GETDATE()
ORDER BY EmployeeID

--Ex 8. Employee 24 
--Write a query that selects: EmployeeID, FirstName, ProjectName Filter all the projects of employee with Id 24. If the project has started during or after 2005 the returned value should be NULL.
SELECT e.EmployeeID, e.FirstName, 
		CASE WHEN StartDate < '2005-01-01'THEN p.[Name]
		ELSE NULL
		END AS ProjectName
	FROM [SoftUni].[dbo].[Employees] e
		LEFT JOIN [SoftUni].[dbo].[EmployeesProjects] ep ON e.EmployeeID = ep.EmployeeID
		LEFT JOIN [SoftUni].[dbo].[Projects] p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

--Ex 9. Employee Manager
--Write a query that selects: EmployeeID, FirstName, ManagerID, ManagerName.Filter all employees with a manager who has ID equals to 3 or 7. Return all the rows, sorted by EmployeeID in ascending order.
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
	FROM [SoftUni].[dbo].[Employees] e 
	LEFT JOIN [SoftUni].[dbo].[Employees] m ON e.ManagerID = m.EmployeeID
	WHERE e.ManagerID IN (3,7)
ORDER BY EmployeeID

--Ex 10. See Lab 6
--Ex 11. See Lab 8
--USE DB Geography
--Ex 12. Highest Peaks in Bulgaria
--Write a query that selects: CountryCode, 	MountainRange, PeakName, Elevation. Filter all peaks in Bulgaria with elevation over 2835. Return all the rows sorted by elevation in descending order.
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
  FROM [Geography].[dbo].[Countries] c
	  JOIN [Geography].[dbo].[MountainsCountries] mc ON c.CountryCode = mc.CountryCode
	  JOIN [Geography].[dbo].[Mountains] m ON mc.MountainId = m.Id
	  JOIN [Geography].[dbo].[Peaks] p ON p.MountainId = m.Id
	WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Ex 13. Count Mountain Ranges
--Write a query that selects: CountryCode, MountainRanges. Filter the count of the mountain ranges in the United States, Russia and Bulgaria.
SELECT c.CountryCode, COUNT(m.MountainRange) AS NmbrMountains
  FROM [Geography].[dbo].[Countries] c
	  JOIN [Geography].[dbo].[MountainsCountries] mc ON c.CountryCode = mc.CountryCode
	  JOIN [Geography].[dbo].[Mountains] m ON mc.MountainId = m.Id
	WHERE c.CountryCode IN ('BG','US','RU')
GROUP BY c.CountryCode

--Ex 14. Countries with Rivers
--Write a query that selects: CountryName, RiverName. Find the first 5 countries with or without rivers in Africa. Sort them by CountryName in ascending order.

SELECT TOP(5) c.CountryName, r.RiverName
  FROM [Geography].[dbo].[Countries] c
	LEFT JOIN [Geography].[dbo].[Continents] cc ON c.ContinentCode = cc.ContinentCode
	LEFT JOIN [Geography].[dbo].[CountriesRivers] cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN [Geography].[dbo].[Rivers] r ON cr.RiverId = r.Id
	WHERE ContinentName = 'Africa'
ORDER BY c.CountryName

--Ex 15. Continents and Currencies
--Write a query that selects: ContinentCode, CurrencyCode, CurrencyUsage. Find all continents and their most used currency. Filter any currency that is used in only one country. Sort your results by ContinentCode.
SELECT ContinentCode, CurrencyCode, CountCur AS CurrencyUsage
	FROM
	(SELECT ContinentCode, CurrencyCode, CountCur,
			DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CountCur DESC) AS Rank
			FROM 
			(SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CurrencyCode) AS CountCur
			  FROM [Geography].[dbo].[Countries] c
				JOIN [Geography].[dbo].[Currencies] cr ON c.CurrencyCode = cr.CurrencyCode
			GROUP BY c.ContinentCode, c.CurrencyCode) AS tmp) AS tmp2
	WHERE Rank = 1 AND CountCur != 1
ORDER BY ContinentCode ASC, CurrencyCode ASC
--Ex 16. Countries Without Any Mountains
--Find all the count of all countries, which donТt have a mountain.

SELECT COUNT(CountryCode) AS Count FROM
	(SELECT c.CountryCode, m.MountainRange
	  FROM [Geography].[dbo].[Countries] c
		  LEFT JOIN [Geography].[dbo].[MountainsCountries] mc ON c.CountryCode = mc.CountryCode
		  LEFT JOIN [Geography].[dbo].[Mountains] m ON mc.MountainId = m.Id
	WHERE m.MountainRange IS NULL) AS tmp
--Ex 17. Highest Peak and Longest River by Country
--For each country, find the elevation of the highest peak and the length of the longest river, sorted by the highest peak elevation (from highest to lowest), then by the longest river length (from longest to smallest), then by country name (alphabetically). Display NULL when no data is available in some of the columns. Limit only the first 5 rows.

SELECT TOP(5) CountryName, Elevation, [Length]
	FROM
	(SELECT c.CountryName, p.PeakName, p.Elevation, r.RiverName, r.[Length],
			DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY p.Elevation DESC) AS RankPeaks,
			DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY r.[Length] DESC) AS RankRivers
	  FROM [Geography].[dbo].[Countries] c
		  LEFT JOIN [Geography].[dbo].[MountainsCountries] mc ON c.CountryCode = mc.CountryCode
		  LEFT JOIN [Geography].[dbo].[Mountains] m ON mc.MountainId = m.Id
		  LEFT JOIN [Geography].[dbo].[Peaks] p ON p.MountainId = m.Id
		  LEFT JOIN [Geography].[dbo].[CountriesRivers] cr ON c.CountryCode = cr.CountryCode
		  LEFT JOIN [Geography].[dbo].[Rivers] r ON cr.RiverId = r.Id) AS tmp
	WHERE RankPeaks = 1 AND RankRivers = 1
ORDER BY Elevation DESC, [Length] DESC, CountryName

--Ex 18. Highest Peak Name and Elevation by Country
--For each country, find the name and elevation of the highest peak, along with its mountain. When no peaks are available in some country, display elevation 0, "(no highest peak)" as peak name and "(no mountain)" as mountain name. When multiple peaks in some country have the same elevation, display all of them. Sort the results by country name alphabetically, then by highest peak name alphabetically. Limit only the first 5 rows.
SELECT TOP(5) CountryName AS Country, 
		CASE
			WHEN PeakName IS NULL THEN '(no highest peak)'
			ELSE PeakName
		END AS [Highest Peak Name], 
		CASE
			WHEN Elevation IS NULL THEN 0
			ELSE Elevation
		END AS [Highest Peak Elevation], 
		CASE
			WHEN MountainRange IS NULL THEN '(no mountain)'
			ELSE MountainRange
		END AS Mountain
	FROM
	(SELECT c.CountryName, m.MountainRange, p.PeakName, p.Elevation,
			DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY p.Elevation DESC) AS RankPeaks
	  FROM [Geography].[dbo].[Countries] c
		  LEFT JOIN [Geography].[dbo].[MountainsCountries] mc ON c.CountryCode = mc.CountryCode
		  LEFT JOIN [Geography].[dbo].[Mountains] m ON mc.MountainId = m.Id
		  LEFT JOIN [Geography].[dbo].[Peaks] p ON p.MountainId = m.Id) AS tmp
	WHERE RankPeaks = 1 
ORDER BY CountryName, [Highest Peak Name]
