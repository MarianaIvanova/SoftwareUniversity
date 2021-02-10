--Lecture

--Lab 1. Когато създадем Primary Key в една таблица на бази данни, автоматично създаваме клъстеризиран индекс! В една таблица може да има само един клъстеризиран индекс.
--Use PerformanceDB.sql to create DB with more the 40 milions lines - the files of the DB are respectively 4 GB and 1,5 GB
--Non-Clustered Index:
USE PerformanceDB
CREATE NONCLUSTERED INDEX IX_Messages_MsgPrice ON Messages(MsgPrice) --Messages(MsgPrice, , , , )
SELECT COUNT(*) FROM Messages WHERE MsgPrice > 100000 AND MsgPrice < 200000

DROP INDEX IDX_Messages_MsgPrice ON Messages

--Lab 2. GROUP BY - allows us  to get each separate group and use it with the aggregation functions
SELECT DepartmentID
  FROM [SoftUni].[dbo].[Employees]
  GROUP BY DepartmentID
--Lab 3. Aggregation functions
SELECT DepartmentID, COUNT(*) AS Nmbr, SUM(Salary) AS TotalSalary, AVG(Salary) AS AVGSalary, MIN(Salary) AS MINSalary, MAX(Salary) AS MAXSalary, STRING_AGG(FirstName, ' ') AS EmployeesNames
  FROM [SoftUni].[dbo].[Employees]
  GROUP BY DepartmentID

--3.1 COUNT -- COUNT ignores any employee with NULL salary.
--when we want to know only the number of lines:

--when we want to know how many people have salaries in the table (we don't count NULL, if we have NULL's in the salary, the number of the lines and the number of the salaries will be different!)

--when we want to know how many unique salaries we have
SELECT DepartmentID, COUNT(*) AS NmbrLines, COUNT(Salary) AS NmbrSalaries,
	COUNT(DISTINCT(Salary)) AS NmbrUniqueSalaries,
	STRING_AGG(Salary,'--') AS AllSalaies
  FROM [SoftUni].[dbo].[Employees]
  GROUP BY DepartmentID

--SUM - sums the values in a column. If any department has no salaries, it returns NULL.
SELECT DepartmentID, SUM(Salary) AS TotalSalary, STRING_AGG(Salary, '--') AS AllSalaies
  FROM [SoftUni].[dbo].[Employees]
  GROUP BY DepartmentID

--MAX/ MIN - takes the largest/smallest value in a column. It can be used not only on numbers, but on CHARS too
SELECT DepartmentID, MIN(Salary) AS MINSalary, MAX(Salary) AS MAXSalary, STRING_AGG(Salary, '--') AS AllSalaies
  FROM [SoftUni].[dbo].[Employees]
  GROUP BY DepartmentID

--AVG - calculates the average value in a column. 
--It is different from median: PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY Salary DESC) OVER (PARTITION BY DepartmentId) AS MedianCont - SEE BuiltInFunctions.sql (median doesn't work group by)
--Statistics function - see int net Mode (the one we meet most), Range(max - min)
--Standard Deviation - STDEV(Salary) AS StdDev
SELECT DepartmentID, AVG(Salary) AS AVGSalary, STRING_AGG(Salary, '--') AS AllSalaies
  FROM [SoftUni].[dbo].[Employees]
  GROUP BY DepartmentID

--STRING_AGG - Concatenates the values of string expressions and places separator values between them. The separator is not added at the end of string
SELECT DepartmentID, STRING_AGG(Salary, '--') AS AllSalaies
  FROM [SoftUni].[dbo].[Employees]
  GROUP BY DepartmentID

--Lab 4. Departments Total Salaries
--Use "SoftUni" database to create a query which prints the total sum of salaries for each department. Order them by DepartmentID (ascending).
SELECT e.DepartmentID, d.Name AS DepartmentName, COUNT(*) AS Nmbr, SUM(Salary) AS TotalSalary
  FROM [SoftUni].[dbo].[Employees] e
  LEFT JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
  GROUP BY e.DepartmentID, d.Name
ORDER BY e.DepartmentID

--Lab 5. HAVING (like WHERE but after GROUP BY). We can use subquery if we don't want to use HAVING, but it's better to use HAVING
SELECT d.[Name] AS DepartmentName, COUNT(*) AS Nmbr, AVG(Salary) AS AVGSalary
  FROM [SoftUni].[dbo].[Employees] e
    LEFT JOIN [SoftUni].[dbo].[Departments] d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] LIKE 'E%'
  GROUP BY d.[Name]
  HAVING AVG(Salary)> 30000

--Exercises
--USING Gringotts database
USE Gringotts
--Ex 1. Records’ Count
--Import the database and send the total count of records from the one and only table to Mr. Bodrog. Make sure nothing got lost.
SELECT COUNT(*) AS Count
  FROM [Gringotts].[dbo].[WizzardDeposits]

--Ex 2. Longest Magic Wand
--Select the size of the longest magic wand. Rename the new column appropriately.
SELECT MAX(MagicWandSize) AS LongestMagicWand
  FROM [Gringotts].[dbo].[WizzardDeposits]

--Ex 3. Longest Magic Wand Per Deposit Groups
--For wizards in each deposit group show the longest magic wand. Rename the new column appropriately.
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
  FROM [Gringotts].[dbo].[WizzardDeposits]
GROUP BY DepositGroup

--Ex 4. Smallest Deposit Group Per Magic Wand Size
--Select the two deposit groups with the lowest average wand size.
SELECT TOP(2) DepositGroup FROM
	(SELECT DepositGroup, AVG(MagicWandSize) AS AVGMagicWand
	  FROM [Gringotts].[dbo].[WizzardDeposits]
	GROUP BY DepositGroup) AS tmp
ORDER BY AVGMagicWand

--Ex 5. Deposits Sum
--Select all deposit groups and their total deposit sums.
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	  FROM [Gringotts].[dbo].[WizzardDeposits]
	GROUP BY DepositGroup

--Ex 6. Deposits Sum for Ollivander Family
--Select all deposit groups and their total deposit sums but only for the wizards who have their magic wands crafted by Ollivander family.
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	  FROM [Gringotts].[dbo].[WizzardDeposits]
	  WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
--Ex 7. Deposits Filter
--Select all deposit groups and their total deposit sums but only for the wizards who have their magic wands crafted by Ollivander family. Filter total deposit amounts lower than 150000. Order by total deposit amount in descending order.
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	  FROM [Gringotts].[dbo].[WizzardDeposits]
	  WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY SUM(DepositAmount) DESC

--Ex 8. Deposit Charge
--Create a query that selects: Deposit group, Magic wand creator, Minimum deposit charge for each group. Select the data in ascending ordered by MagicWandCreator and DepositGroup.
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
	  FROM [Gringotts].[dbo].[WizzardDeposits]
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup

--Ex 9. Age Groups
--Write down a query that creates 7 different groups based on their age.
--Age groups should be as follows:[0-10], [11-20], [21-30], [31-40], [41-50], [51-60], [61+]
--The query should return: Age groups, Count of wizards in it
SELECT 
		CASE 
			WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
			WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
			WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
			WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
			WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
			WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS AgeGroup,		
		COUNT(FirstName) AS WizardCount
	  FROM [Gringotts].[dbo].[WizzardDeposits]
	GROUP BY 
		CASE 
			WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
			WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
			WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
			WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
			WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
			WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
			ELSE '[61+]'
		END

--Ex 10. First Letter
--Write a query that returns all unique wizard first letters of their first names only if they have deposit of type Troll Chest. Order them alphabetically. Use GROUP BY for uniqueness.
SELECT LEFT(FirstName,1) AS FirstLetter
	  FROM [Gringotts].[dbo].[WizzardDeposits]
	  WHERE DepositGroup = 'Troll Chest'
	  GROUP BY LEFT(FirstName,1)

--Ex 11. Average Interest 
--Mr. Bodrog is highly interested in profitability. He wants to know the average interest of all deposit groups split by whether the deposit has expired or not. But that’s not all. He wants you to select deposits with start date after 01/01/1985. Order the data descending by Deposit Group and ascending by Expiration Flag. The output should consist of the following columns: DepositGroup, IsDepositExpired, AverageInterest
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
	  FROM [Gringotts].[dbo].[WizzardDeposits]
	  WHERE DepositStartDate > '1985-01-01'
	  GROUP BY DepositGroup, IsDepositExpired
	  ORDER BY DepositGroup DESC, IsDepositExpired

--Ex 12. Rich Wizard, Poor Wizard
--Mr. Bodrog definitely likes his werewolves more than you. This is your last chance to survive! Give him some data to play his favorite game Rich Wizard, Poor Wizard. The rules are simple: You compare the deposits of every wizard with the wizard after him. If a wizard is the last one in the database, simply ignore it. In the end you have to sum the difference between the deposits.
--12.1 Mine
SELECT SUM(Amnt) AS SumDifference FROM
	(SELECT 
		CASE 
			WHEN Id = 1 THEN DepositAmount
			WHEN Id = (SELECT COUNT(*) FROM [Gringotts].[dbo].[WizzardDeposits]) THEN - DepositAmount
			ELSE 0
		END AS Amnt
		FROM [Gringotts].[dbo].[WizzardDeposits]) AS tmp
--12.2 Ex
SELECT SUM(Diff) AS SumDifference
	FROM
	(SELECT (a.DepositAmount - b.DepositAmount) AS Diff
		FROM
		(SELECT Id, DepositAmount
			FROM [Gringotts].[dbo].[WizzardDeposits]) AS a
		JOIN 
			(SELECT Id, DepositAmount
				FROM [Gringotts].[dbo].[WizzardDeposits]) AS b
		ON a.Id = b.Id - 1) AS tmp


--Ex 13. Departments Total Salaries
--That’s it! You no longer work for Mr. Bodrog. You have decided to find a proper job as an analyst in SoftUni. It’s not a surprise that you will use the SoftUni database. Things get more exciting here!
--Create a query that shows the total sum of salaries for each department. Order by DepartmentID.
--Your query should return:	DepartmentID
SELECT e.DepartmentID, SUM(Salary) AS TotalSalary
  FROM [SoftUni].[dbo].[Employees] e
  GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

--Ex 14. Employees Minimum Salaries
--Select the minimum salary from the employees for departments with ID (2, 5, 7) but only for those hired after 01/01/2000. Your query should return:	DepartmentID
SELECT e.DepartmentID, MIN(Salary) AS MinSalary
  FROM [SoftUni].[dbo].[Employees] e
  WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01'
  GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

--Ex 15. Employees Average Salaries
--Select all employees who earn more than 30000 into a new table. Then delete all employees who have ManagerID = 42 (in the new table). Then increase the salaries of all employees with DepartmentID=1 by 5000. Finally, select the average salaries in each department.
SELECT * INTO MyNewTable 
		FROM [SoftUni].[dbo].[Employees]
		WHERE Salary > 30000

DELETE FROM MyNewTable
	WHERE ManagerID = 42

UPDATE MyNewTable
SET Salary = Salary + 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
	FROM MyNewTable
GROUP BY DepartmentID

--Ex 16. Employees Maximum Salaries
--Find the max salary for each department. Filter those, which have max salaries NOT in the range 30000 – 70000.
SELECT DepartmentID, MAX(Salary) AS MAXSalary
  FROM [SoftUni].[dbo].[Employees]
  GROUP BY DepartmentID
HAVING MAX(Salary) < 30000 OR  MAX(Salary) > 70000

--Ex 17. Employees Count Salaries
--Count the salaries of all employees who don’t have a manager.
SELECT COUNT(*) AS NoSalary
  FROM [SoftUni].[dbo].[Employees]
	WHERE ManagerID IS NULL

--Ex 18. 3rd Highest Salary
--Find the third highest salary in each department if there is such. 
SELECT DepartmentID, Salary AS ThirdHighestSalary
	FROM
	(SELECT DepartmentID, Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
	  FROM [SoftUni].[dbo].[Employees]) AS tmp
  WHERE Rank = 3
  GROUP BY DepartmentID, Salary

--Ex 19. Salary Challenge
--Write a query that returns: FirstName, LastName, DepartmentID
--Select all employees who have salary higher than the average salary of their respective departments. Select only the first 10 rows. Order by DepartmentID.
SELECT TOP(10) a.FirstName, a.LastName, a.DepartmentID
		FROM
		(SELECT FirstName, LastName, DepartmentID, Salary
			  FROM [SoftUni].[dbo].[Employees]) AS a
			  JOIN 
				(SELECT DepartmentID, AVG(Salary) AS AVGSalary
					  FROM [SoftUni].[dbo].[Employees]
					GROUP BY DepartmentID) AS b
			 ON a.DepartmentID = b.DepartmentID
		WHERE a.Salary > b.AVGSalary
ORDER BY DepartmentID