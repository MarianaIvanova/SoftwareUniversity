--Lab 1. �� ������ SoftUni ���� � ������, � ����� ��� � ��������, � ��������:
SELECT FirstName, LastName FROM Employees
	where HireDate > '01-01-2002'
--Lab 2. Join � ������ ����� �� �� �� ����� ������������ ��������� �� ������� �������.
SELECT FirstName, LastName, Employees.AddressID, Addresses.* 
	FROM Employees
	JOIN Addresses ON Employees.AddressID = Addresses.AddressID
	where HireDate > '01-01-2002'
--Lab 3. ����� �� ������������ ������ ����
SELECT 1 as Digit, FirstName, LastName,  Salary, JobTitle as JobPosition
	FROM Employees
--Lab 4. ����� �� ��������� ���� ���� �� �� ���������� - ���� � ����� ������� ��� JOIN
SELECT e.FirstName, e.LastName,  e.Salary, e.JobTitle
	FROM Employees AS e -- ��� �������� �� ������ e �.�. FROM Employees e
--Lab 5. ����� �� �������� �������� ������, ����� � CSharp � +, �.�. �.���. ������������
SELECT FirstName, LastName, FirstName + ' ' + LastName as FullName
	FROM Employees
--Lab 6. ����� �� ������ ������ � �����, ����� � ������� ��� ������ ������, ����������� ��.�������
SELECT FirstName,
		LastName, 
		FirstName + ' ' + LastName as FullName,
		'Niki''s Cell' as AddedColumn-- Niki's Cell
	FROM Employees
--Lab 7. ����� �� ������ ������� ��� ����� �� ��������� ��������:
SELECT FirstName,
		LastName, 
		LEFT(LastName,2) as ShortLastName,
		SUBSTRING(LastName, 1, 2) as ShortLastName2
	FROM Employees
--Lab 8. ��� ������ �� ��������� �������� � ��� ������� ���� ��� �� ���������� �������, ��� �� ���������� ������� ����, ������ �� �������� ������ � ��������� ����� (����� ��������� ���):
SELECT FirstName, LastName, FirstName + ' ' + LastName as [Full Name]
	FROM Employees
--Lab 9. Find information about all employees, listing their full name, job title and salary
SELECT FirstName + ' ' + LastName as [Full Name], 
		JobTitle, 
		Salary
	FROM Employees
--Lab 10. ��� ������ �� ������ �� ������, � ���� ������� 10 ���� ��������:
SELECT TOP(10)
		FirstName + ' ' + LastName as [Full Name], 
		JobTitle, 
		Salary
	FROM Employees
--Lab 11. ��� ����� ������� ��������� �� ������, ���� ��������� ������� ��� ���������� � � ������� ��� 
SELECT DISTINCT --������������ �� DISTINCT ������ 293 � ������������ ���� ������� 58 ����
		JobTitle
	FROM Employees 
--Lab 12. ��� ����� ���������� �������� �������, ����� ������ �� ����� ���������
SELECT *
	FROM Employees 
	WHERE Salary > 50000
SELECT *
	FROM Employees 
	WHERE HireDate > '2005-01-01'
SELECT *
	FROM Employees 
	WHERE HireDate > '2005'--������ ���� �������
SELECT *
	FROM Employees 
	WHERE FirstName > 'X' -- ������ �����, ��������� � Y � Z
--Lab 13. ��� ����� ���������� ����� �������, ����� ������ �� ����� ��������� AND, OR, NOT 
SELECT *
	FROM Employees 
	WHERE Salary > 50000 AND
		HireDate > '2002-01-01'
SELECT *
	FROM Employees 
	WHERE Salary > 50000 OR
		DepartmentID = 1
SELECT *
	FROM Employees 
	WHERE NOT (Salary > 50000 OR
		DepartmentID = 1) --��������� �� �������
SELECT *
	FROM Employees 
	WHERE Salary <= 50000 AND
		DepartmentID != 1 --������ ���� �������
--Lab 14. ��� ����� ����, ����� �� � � ��������� ��������
SELECT *
	FROM Employees 
	WHERE Salary >= 20000 AND Salary <= 40000
SELECT *
	FROM Employees 
	WHERE Salary BETWEEN 20000 AND 40000 --������ ���� �������
--Lab 15. ��� ����� ����, ����� �� � � ��������� ������ ��� �� �� � � ����
SELECT *
	FROM Employees 
	WHERE Salary IN (20000, 50000, 50500, 60000)
SELECT *
	FROM Employees 
	WHERE Salary NOT IN (20000, 50000, 50500, 60000)
--Lab 16. ���������� � NULL
SELECT *
	FROM Employees 
	WHERE MiddleName IS NULL
SELECT *
	FROM Employees 
	WHERE MiddleName IS NOT NULL
--Lab 17. ������� �� ���� �� �������� ���. �����, ����� � ������ ��� ���� ���� �� ��������� �������, �� �� ���������, �� ��� � �������� �� ��� �����. ��� ����� �� ������� � PATTERN �� RegEx
SELECT *
	FROM Employees 
	WHERE JobTitle LIKE '%manager%' --case insensitive! If we change the column collation - it will be sensitive for this column
--Lab 18. ��������� ��������� � ��������� �� ���������� ������
SELECT *
	FROM Employees 
	WHERE Salary > 20000
	ORDER BY FirstName ASC -- �� � ������������ �� �� ���� ASC - �� � �� ������������
SELECT *
	FROM Employees 
	WHERE Salary > 20000
	ORDER BY FirstName DESC 
SELECT *
	FROM Employees 
	WHERE Salary > 20000
	ORDER BY FirstName ASC, LastName DESC -- ��� ����� �� ������� �� ���, �� �� ��������� ����� �� ������� � �� �������

SELECT 	FirstName + ' ' + LastName as [Full Name], 
		JobTitle, 
		Salary,
		RAND() AS Rand --��������� � ������ �����
	FROM Employees 
	WHERE Salary > 20000
	ORDER BY [Full Name] ASC -- ��� ��������� �� ������, ����� ��������� ��� ������

SELECT 	FirstName + ' ' + LastName as [Full Name], 
		JobTitle, 
		Salary
	FROM Employees 
	WHERE Salary > 50000
	ORDER BY NEWID()-- ��������� �� ������ �������

SELECT 	FirstName + ' ' + LastName as [Full Name], 
		JobTitle, 
		Salary * EmployeeID
	FROM Employees 
	WHERE Salary > 50000
	ORDER BY Salary * EmployeeID

--Lab 19. ������, ����� �� ����� � ������ ����� ��� ������� �� View. 
--Highest salaries

CREATE VIEW v_EmployeesWithHighestSalaries AS --ALTER VIEW �� ������� �� VIEW-��
SELECT 	FirstName + ' ' + LastName as [Full Name], 
		JobTitle, 
		Salary
	FROM Employees 
	WHERE Salary > 40000
--������ ��������� ���� view - ����� ���� � SELECT * FROM v_EmployeesWithHighestSalaries - �� �� �������!

--Lab 20. Problem: Highest Peak
--Create a view that selects all information about the highest peak
--Name the view v_HighestPeak //Everest with id 68
--Note: Query Geography database
CREATE VIEW v_HighestPeak AS
SELECT TOP(1) *
	FROM Peaks
	ORDER BY Elevation DESC

--Lab 21. ��������� �� ����� � �������
INSERT INTO Peaks (PeakName, MountainId, Elevation) 
	VALUES ('Mancho', 17, 2771), --it should be Latin, cause the coulumn has been defined this way
		   ('Deno', 17, 2790),
		   ('Aleko', 17, 2719)

--Lab 22. ��������� � ������������ ������� �� �����, ����� �� select query �� ����� �������
INSERT INTO Projects ([Name], [Description], StartDate, EndDate) 
SELECT [Name] + 'Restucturing...',
	   [Name] + 'Restucturing...',
	   GETDATE(),
	   NULL
	FROM Departments

--Lab 23. ��������� � ���� ������� �� �����, ����� �� select query �� ����� �������
SELECT FirstName + ' ' + LastName AS [Full Name], Salary
	INTO NamesWithSalaries
	FROM Employees

--Lab 24. ��������� �� ����� �� ������� - ����� ������ ����� select * (�� �� ����� ��������� ��������), ���� ����� �� �������� � delete
DELETE FROM NamesWithSalaries
	WHERE Salary < 50000
DELETE FROM NamesWithSalaries --������� ������, �� �� ������ id-�� (��� ��� ����� id-�� ������� �� ���, �� ������ � ��������)
TRUNCATE TABLE NamesWithSalaries -- ������� ��������� ������, ����������� ������ id-��, ��� ���� ���� �������, ��� ������ ����� ��� ����!
--Lab 25. ������� �� ����� � ������� ��� ���������� ������� - ����� ������ ����� select * (�� �� ����� ��������� ��������), ���� ����� �� �������� � UPDATE
UPDATE NamesWithSalaries
	SET Salary = Salary * 0.9, --�������� �� ������ ���������, ��� � ��-������ �� 60000
		[Full Name] = '_' + [Full Name]
	WHERE Salary > 60000
--SELECT * FROM NamesWithSalaries
--Lab 26. Problem: Update Projects
--Mark all unfinished Projects as being completed today
--Hint: Unfinished projects have their EndDate set to NULL
--Note: Query SoftUni database
UPDATE Projects
	SET EndDate = '2021-01-14' -- ��-����� �� ����� GETDATE() �� ������ ����
	WHERE EndDate IS NULL

--EXERCISES
--Ex 1. Download and get familiar with the SoftUni, Diablo and Geography database schemas and tables. 
--A FOREIGN KEY constraint referencing the same table is typically for a hierarchy structure and it would use another column to reference the primary key. A good example is a table of employees:
--EmployeeId    Int     Primary Key
--EmployeeName  String
--ManagerId     Int     Foreign key going back to the EmployeeId
--So in this case there is a foreign key from the table back to itself. All managers are also employees so the ManagerId is actually the EmployeeId of the manager.
--Now on the other hand if you mean someone used the EmployeeId as the foreign key back to the Employee table then it was probably a mistake. I did run a test and it's possible but it wouldn't have any real use.
--Perhaps the designer wanted to disable the use of TRUNCATE TABLE?
--TRUNCATE TABLE cannot be used on a table with a foreign key constraint to another table though it can be used if there are self-referential foreign keys. 
--see https://dba.stackexchange.com/questions/81311/why-would-a-table-use-its-primary-key-as-a-foreign-key-to-itself

--Ex 2. Write a SQL query to find all available information about the Departments.
SELECT * FROM Departments
--Ex 3. Write SQL query to find all Department names.
SELECT [Name] FROM Departments
--Ex 4. Write SQL query to find the first name, last name and salary of each employee.
SELECT FirstName, LastName, Salary FROM Employees
--Ex 5. Write SQL query to find the first, middle and last name of each employee. 
SELECT FirstName, MiddleName, LastName FROM Employees
--Ex 6. Write a SQL query to find the email address of each employee. (By his first and last name). Consider that the email domain is softuni.bg. Emails should look like �John.Doe@softuni.bg". The produced column should be named "Full Email Address". 
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
	FROM Employees
--Ex 7. Write a SQL query to find all different employee�s salaries. Show only the salaries.
SELECT DISTINCT Salary
	FROM Employees
--Ex 8. Write a SQL query to find all information about the employees whose job title is �Sales Representative�. 
SELECT *
	FROM Employees
	WHERE JobTitle = 'Sales Representative'
--Ex 9. Write a SQL query to find the first name, last name and job title of all employees whose salary is in the range [20000, 30000].
SELECT FirstName, LastName, JobTitle
	FROM Employees
	WHERE Salary BETWEEN 20000 AND 30000
--Ex 10. Write a SQL query to find the full name of all employees whose salary is 25000, 14000, 12500 or 23600. Full Name is combination of first, middle and last name (separated with single space) and they should be in one column called �Full Name�.
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
	FROM Employees
	WHERE Salary IN (25000, 14000, 12500, 23600)
--Ex 11. Write a SQL query to find first and last names about those employees that does not have a manager. 
SELECT FirstName, LastName
	FROM Employees
	WHERE ManagerID IS NULL
--Ex 12. Write a SQL query to find first name, last name and salary of those employees who has salary more than 50000. Order them in decreasing order by salary.  
SELECT FirstName, LastName, Salary
	FROM Employees
	WHERE Salary > 50000
	ORDER BY Salary DESC
--Ex 13. Write SQL query to find first and last names about 5 best paid Employees ordered descending by their salary.
SELECT TOP(5) FirstName, LastName
	FROM Employees
	ORDER BY Salary DESC
--Ex 14.Write a SQL query to find the first and last names of all employees whose department ID is different from 4. 
SELECT FirstName, LastName
	FROM Employees
	WHERE DepartmentID != 4
--Ex 15. Write a SQL query to sort all records in the Employees table by the following criteria: 
--�	First by salary in decreasing order
--�	Then by first name alphabetically
--�	Then by last name descending
--�	Then by middle name alphabetically
SELECT *
	FROM Employees
	ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC
--Ex 16.Write a SQL query to create a view V_EmployeesSalaries with first name, last name and salary for each employee.
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
	FROM Employees
--Ex 17.Write a SQL query to create view V_EmployeeNameJobTitle with full employee name and job title. When middle name is NULL replace it with empty string (��).
--17.1
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CASE
		WHEN MiddleName IS NOT NULL THEN FirstName +' ' + MiddleName +' ' +  LastName
		ELSE FirstName +' ' + ' ' + LastName
		END AS [Full Name],
		JobTitle
	FROM Employees
--17.2 
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName +' ' + ISNULL(MiddleName, '') +' ' +  LastName AS [Full Name],
		JobTitle
	FROM Employees

--Ex 18. Write a SQL query to find all distinct job titles.
SELECT DISTINCT JobTitle
	FROM Employees
--Ex 19. Write a SQL query to find first 10 started projects. Select all information about them and sort them by start date, then by name.
SELECT TOP(10) *
	FROM Projects
	ORDER BY StartDate, [Name]
--Ex 20. Write a SQL query to find last 7 hired employees. Select their first, last name and their hire date.
SELECT TOP(7) FirstName, LastName, HireDate
	FROM Employees
	ORDER BY HireDate DESC
--Ex 21. Write a SQL query to increase salaries of all employees that are in the Engineering, Tool Design, Marketing or Information Services department by 12%. Then select Salaries column from the Employees table. After that exercise restore your database to revert those changes.
UPDATE Employees
	SET Salary = Salary * 1.12
	WHERE DepartmentID IN (1, 2, 4, 11)
SELECT Salary
	FROM Employees
UPDATE Employees
	SET Salary = Salary / 1.12
	WHERE DepartmentID IN (1, 2, 4, 11)

SELECT * 
	FROM Departments
--Ex 22. Display all mountain peaks in alphabetical order.
SELECT PeakName
	FROM Peaks
	ORDER BY PeakName ASC
--Ex 23. Find the 30 biggest countries by population from Europe. Display the country name and population. Sort the results by population (from biggest to smallest), then by country alphabetically.
SELECT TOP(30) CountryName, [Population]  
	FROM Countries
	WHERE ContinentCode ='EU'
	ORDER BY [Population] DESC, CountryName ASC
--Ex 24. Find all countries along with information about their currency. Display the country name, country code and information about its currency: either "Euro" or "Not Euro". Sort the results by country name alphabetically.
SELECT CountryName, CountryCode, 
CASE
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
END AS Currency
	FROM Countries
	ORDER BY CountryName

--Ex 25. Display all characters in alphabetical order. 
SELECT DISTINCT [Name] 
	FROM Characters