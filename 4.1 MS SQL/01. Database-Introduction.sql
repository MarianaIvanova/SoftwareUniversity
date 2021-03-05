--1.	Create database:
CREATE DATABASE Minions
--2.	Create tables:
USE Minions --to be sure we are in the correct database
--Minions (Id, Name, Age). Then add new table Towns (Id, Name). 
--Set Id columns of both tables to be primary key as constraint.
CREATE TABLE Minions --to execute only creating the table we should select only below text and press execute
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(30),--as Name is a key word in the code - it should be in []
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50)
)
--3.	Alter Minions Table
--Change the structure of the Minions table to have new column TownId that would be 
--of the same type as the Id column of Towns table. 
--Add new constraint that makes TownId foreign key and references to Id column of Towns table.
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns (Id)

--4. Insert records in both tables
--Minions		Towns
--Id	Name	Age	   TownId		Id	Name
--1	    Kevin	22	    1		    1	Sofia
--2	    Bob		15		3			2	Plovdiv
--3	    Steward	NULL	2			3	Varna

INSERT INTO Towns (Id, Name) VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO Minions (Id, Name, Age, TownId) VALUES
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

select * from towns
select * from minions

--5. Delete all the data from the Minions table
DELETE FROM minions
--WHERE Id = 1
select * from minions

--6. Drop All Tables 
DROP TABLE Minions --should drop first this table, then Towns. Otherwise can't!!!
DROP TABLE Towns

--7. Create new table People
--•	Id – unique number for every person there will be no more than 2^31-1 people. (Auto incremented)
--•	Name – full name of the person will be no more than 200 Unicode characters. (Not null)
--•	Picture – image with size up to 2 MB. (Allow nulls)
--•	Height –  In meters. Real number precise up to 2 digits after floating point. (Allow nulls)
--•	Weight –  In kilograms. Real number precise up to 2 digits after floating point. (Allow nulls)
--•	Gender – Possible states are m or f. (Not null)
--•	Birthdate – (Not null)
--•	Biography – detailed biography of the person it can contain max allowed Unicode characters. (Allow nulls)
--Make Id primary key. Populate the table with only 5 records. 
--Submit your CREATE and INSERT statements as Run queries & check DB.

USE Minions
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARCHAR(MAX),
	--Picture VARBINARY(2000),	image
	Height FLOAT(2),
	[Weight] FLOAT(2),
	Gender CHAR(1) NOT NULL CHECK (Gender = 'm' OR Gender = 'f'),
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX) -- max allowed Unicode characters
)
INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('IVAN IVANOV', 'https://github.com/MikeRayMSFT', 185, 75, 'm', '04/08/2020', 'fkjhjgh'),
('IVAN IVANOV2', 'https://github.com/MikeRayMSFT', 180, 70, 'm', '05/07/2020', 'shh'),
('IVANKA IVANOVA3', 'https://github.com/MikeRayMSFT', 175, 65, 'f', '06/06/2020', 'nothing'),
('IVAN IVANOV4', 'https://github.com/MikeRayMSFT', 170, 60, 'm', '07/05/2020', 'wow'),
('IVANKA IVANOVA5', 'https://github.com/MikeRayMSFT', 165, 60, 'f', '08/04/2019', 'check')
select * from People

--8. Create new table Users
--•	Id – unique number for every user. There will be no more than 2^63-1 users. (Auto incremented)
--•	Username – unique identifier of the user will be no more than 30 characters (non Unicode). (Required)
--•	Password – password will be no longer than 26 characters (non Unicode). (Required)
--•	ProfilePicture – image with size up to 900 KB. 
--•	LastLoginTime
--•	IsDeleted – shows if the user deleted his/her profile. Possible states are true or false.
--Make Id primary key. Populate the table with exactly 5 records. 
--Submit your CREATE and INSERT statements as Run queries & check DB.

CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY, --search for sql servers data type 2^63 IDENTITY(1,1), IDENTITY(1,10) - ñòúïêàòà å 10, íå 1 âå÷å
	Username VARCHAR(30) NOT NULL, --unique???
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	--mine: ProfilePicture VARBINARY(900),--should keep here link, 
	--not a pics as we have done it here and when insert - it's complicated
	LastLoginTime DATETIME,
	IsDeleted BIT --it is 1/true or 0/false
	--mine: IsDeleted CHAR NOT NULL CHECK(IsDeleted = 'true' OR IsDeleted = 'false')
)
INSERT INTO Users 
(Username,[Password], ProfilePicture, LastLoginTime,  IsDeleted) 
VALUES 
('Ivan', 'stongpassward123', 'https://github.com/rothja', '5/12/2020', 0),
('Pesho', 'stongpassward123hfhf', 'https://github.com/rothja', '1/12/2020', 0),
('Maria', 'stongpassward123rjhewh', 'https://github.com/rothja', '11/12/2020', 0),
('Gosho', 'stongpassward123fjf', 'https://github.com/rothja', '8/12/2020', 0),
('Petia', 'stongpassward123fjfj', 'https://github.com/rothja', '2/12/2020', 1)

select * from Users
--9. Change Primary Key
--Modify table Users from the previous task. 
--First remove current primary key then create new primary key 
--that would be the combination of fields Id and Username.
USE Minions  
ALTER TABLE Users  
DROP CONSTRAINT PK__Users__3214EC072B1B1B20 -- see it from the Keys//or with right click and delete

--10. Add Check Constraint
--Modify table Users. Add check constraint to ensure that the values in the 
--Password field are at least 5 symbols long. 
ALTER TABLE Users  
ADD CONSTRAINT PK_IdUserName PRIMARY KEY (Id, Username)

ALTER TABLE Users  
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN([Password]) > 5)
--When there is data in the field [Password] already, we should check if there are already 
--passwords with less then 5 symbols and to add more, otherwise it will show mistake on execution
--other way is to set password > 5 after deleting all data in the table and then insert it again
--this change has insured that no istertion of a password with less then 5 symbol is possible

--11. Set Default Value of a Field
--Modify table Users. Make the default value of LastLoginTime field to be the current time.
ALTER TABLE Users  
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

--12. Set Unique Field
--Modify table Users. Remove Username field from the primary key 
--so only the field Id would be primary key. Now add unique constraint to the Username field 
--to ensure that the values there are at least 3 symbols long.
ALTER TABLE Users  
DROP CONSTRAINT PK_IdUserName
ALTER TABLE Users  
ADD PRIMARY KEY (Id)
--ALTER TABLE Users  -- it can be also like this too
--ADD CONSTRAINT PK_Id PRIMARY KEY (Id)
ALTER TABLE Users  
ADD CONSTRAINT CH_UsernameIsAtLeast3Symbols  CHECK (LEN(Username) > 3)

--13. Movies Database
--Create Movies database with the following entities:
--•	Directors (Id, DirectorName, Notes)
--•	Genres (Id, GenreName, Notes)
--•	Categories (Id, CategoryName, Notes)
--•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
--Set most appropriate data types for each column. Set primary key to each table. 
--Populate each table with exactly 5 records. 
--Make sure the columns that are present in 2 tables would be of the same data type. 
--Consider which fields are always required and which are optional. 
--Submit your CREATE TABLE and INSERT statements as Run queries & check DB.
CREATE DATABASE Movies
USE Movies
CREATE TABLE Directors
(
	Id INT PRIMARY KEY NOT NULL, 
	DirectorName VARCHAR(200) NOT NULL, 
	Notes VARCHAR(MAX)
)
INSERT INTO Directors (Id, DirectorName, Notes) VALUES
(1, 'Petar Petrov', NULL),
(2, 'Ivan Ivanov', 'Note1'),
(3, 'Gosho Goshov','Note2'),
(4, 'Maria Marinova', 'Note3'),
(5, 'Petia Ivanova', 'Note4')
--SELECT * FROM Directors

CREATE TABLE Genres
(
	Id INT PRIMARY KEY NOT NULL,
	GenreName VARCHAR(50),
	Notes VARCHAR(MAX)
)
INSERT INTO Genres (Id, GenreName, Notes) VALUES
(1, 'Comedy-drama', 'NOTE NEW1'),
(2, 'Crime drama', 'NOTE NEW2'),
(3, 'Historical drama', 'NOTE NEW3'),
(4, 'Horror drama', 'NOTE NEW4'),
(5, 'Melodrama', 'NOTE NEW5')
--SELECT * FROM Genres

CREATE TABLE Categories 
(
	Id INT PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(50) NOT NULL, 
	--CHECK(CategoryName = 'Fantasy' OR CategoryName = 'Drama' OR CategoryName = 'Thriller' OR CategoryName = 'Romance' OR CategoryName = 'Mystery' OR CategoryName = 'Horror'),
	Notes VARCHAR(MAX)
)
INSERT INTO Categories (Id, CategoryName, Notes) VALUES
(1, 'Fantasy', 'NOTE-NEW1'),
(2, 'Thriller', 'NOTE-NEW2'),
(3, 'Romance', 'NOTE-NEW3'),
(4, 'Drama', 'NOTE-NEW4'),
(5, 'Horror', 'NOTE-NEW5')
--SELECT * FROM Categories

CREATE TABLE Movies
(
	Id INT PRIMARY KEY NOT NULL,
	Title VARCHAR(MAX),
	DirectorId INT NOT NULL,
	CopyrightYear INT CHECK(CopyrightYear <= 2021 AND CopyrightYear > 1800) NOT NULL,
	Length TIME(2), --'02:30:00:00' If it is TIME(3) - '02:30:00:000'
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes VARCHAR(MAX)
)
INSERT INTO Movies VALUES
(1, 'EFDGKFGRG', 5, 2018, '02:30:00:00', 2, 3, 1, NULL),
(2, 'EFDGKFGRGJHKLLLLJ', 4, 2017, '02:28:00:00', 1, 2, 2, 'NOTE'),
(3, 'JHDHFRJLDDH', 1, 2000, '02:40:00:00', 3, 1, NULL, 'NOTE'),
(4, 'JSDFKJDKFGFFSS', 2, 2011, '02:35:00:00', 4, 4, 3, 'NOTE'),
(5, 'WERITITOTPYPYYY', 3, 2020, '02:20:00:00', 5, 5, 4, 'NOTE')
--SELECT * FROM Movies

--14. CarRental Database
--Create CarRental database with the following entities:
--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
--•	Employees (Id, FirstName, LastName, Title, Notes)
--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
--Set most appropriate data types for each column. Set primary key to each table. 
--Populate each table with only 3 records. Make sure the columns that are present in 2 tables 
--would be of the same data type. Consider which fields are always required and which are optional 
--Submit your CREATE TABLE and INSERT statements as Run queries & check DB.
CREATE DATABASE CarRental
USE CarRental
CREATE TABLE Categories 
(
	Id INT PRIMARY KEY NOT NULL,
	CategoryName CHAR(1) NOT NULL,
	DailyRate INT NOT NULL,
	WeeklyRate INT NOT NULL,
	MonthlyRate INT NOT NULL,
	WeekendRate INT NOT NULL
)
INSERT INTO Categories VALUES
(1,'A', 1, 2, 1, 3),
(2,'B', 2, 1, 3, 2),
(3,'C', 3, 3, 2, 1)
--SELECT * FROM Categories
CREATE TABLE Cars 
(
	Id INT PRIMARY KEY NOT NULL,
	PlateNumber VARCHAR(10) NOT NULL, 
	Manufacturer VARCHAR(50) NOT NULL, 
	Model VARCHAR(20) NOT NULL, 
	CarYear INT CHECK(CarYear <= 2021 AND CarYear > 1800) NOT NULL,
	CategoryId INT NOT NULL, 
	Doors INT NOT NULL, 
	Picture VARCHAR(MAX), 
	Condition VARCHAR(MAX), 
	Available BIT NOT NULL
)
INSERT INTO Cars VALUES
(1, 'CA 1852 XC', 'HDGJHSGH', 'BMW', 2018, 3, 4, 'https://github.com/rothja', 'NOTE1', 1),
(2, 'CA 1540 AH', 'KHSDGK', 'MERCEDES', 2020, 2, 4, 'https://github.com/rothja', 'NOTE2', 0),
(3, 'CO 8567 DF', 'SLSOLGSKSGKSGSGSG', 'RENAULT', 2000, 1, 2, 'https://github.com/rothja', NULL, 1)
--SELECT * FROM Cars

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY NOT NULL, 
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL, 
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO Employees VALUES
(1, 'Ivan', 'Ivanov', 'Junior Seller', NULL),
(2, 'Petar', 'Petov', 'Senior Seller', 'Note1'),
(3, 'Maria', 'Petova', 'Seller', 'Note2')
SELECT * FROM Employees

CREATE TABLE Customers 
(
	Id INT PRIMARY KEY NOT NULL, 
	DriverLicenceNumber VARCHAR(9) NOT NULL, --OR INT
	FullName VARCHAR(100) NOT NULL,
	Address VARCHAR(MAX) NOT NULL,
	City VARCHAR(50) NOT NULL, 
	ZIPCode INT, 
	Notes VARCHAR(MAX)
)
INSERT INTO Customers VALUES
(1,'123456789','Gosho Goshev','EHHFJJKFKF', 'Sofia', 1000, NULL),
(2,'123456781','Ivan Ivanov','sdggdhhh', 'Vratza', 3000, 'note1'),
(3,'123456780','Maria Petrova','wjrsthryoyh', 'Varna', null, 'note2')
--SELECT * FROM Customers

CREATE TABLE RentalOrders 
(
	Id INT PRIMARY KEY NOT NULL, 
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL, 
	TankLevel DECIMAL(15,2) NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL, 
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME NOT NULL, 
	EndDate DATETIME NOT NULL,
	TotalDays INT NOT NULL, 
	RateApplied INT, 
	TaxRate DECIMAL(15,2),
	OrderStatus BIT NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 2, 3, 0.75, 120000, 120500, 500, '10/02/2020', '10/05/2020', 3, 1, 0.20, 1, NULL),
(2, 3, 1, 2, 0.50, 145000, 145520, 520, '10/06/2020', '10/13/2020', 7, 5, 0.20, 1, NULL),
(3, 2, 3, 1, 0.25, 135500, 135580, 80, '10/15/2020', '10/16/2020', 1, NULL, 0.20, 0, 'SZKDJSHH')
--SELECT * FROM RentalOrders

--15. Hotel Database
--Using SQL queries create Hotel database with the following entities:
--•	Employees (Id, FirstName, LastName, Title, Notes)
--•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
--•	RoomStatus (RoomStatus, Notes)
--•	RoomTypes (RoomType, Notes)
--•	BedTypes (BedType, Notes)
--•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
--•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
--•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
--Set most appropriate data types for each column. Set primary key to each table. 
--Populate each table with only 3 records. Make sure the columns that are present in 2 tables 
--would be of the same data type. Consider which fields are always required and which are optional.
--Submit your CREATE TABLE and INSERT statements as Run queries & check DB.

CREATE DATABASE Hotel

USE Hotel
CREATE TABLE Employees 
(
	Id INT PRIMARY KEY, -- IDENTITY,  NOT NULL
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL, 
	Title VARCHAR(50) NOT NULL, 
	Notes VARCHAR(MAX)
)
INSERT INTO Employees (Id, FirstName, LastName, Title, Notes) VALUES
(1, 'Gosho', 'Goshev', 'CEO', NULL),
(2, 'Ivan', 'Ivanov', 'CFO', 'random note'),
(3, 'Ivan', 'Goshev', 'CTO', 'something')
--SELECT * FROM Employees

CREATE TABLE Customers 
(
	AccountNumber INT PRIMARY KEY,-- NOT NULL
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL, 
	EmergencyName VARCHAR(90) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL, 
	Notes VARCHAR(MAX)
)
INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(120, 'G', 'I', '1234567890','A','1234567890', NULL),
(121, 'I', 'I', '1234567890','M','1234567890', 'FILL SOMETHING'),
(123, 'I', 'G', '1234567890','N','1234567890', 'SOMETHING')
--SELECT * FROM Customers

CREATE TABLE RoomStatus --PRIMARY KEY? SHOULD WE ADD Id?
(
	RoomStatus VARCHAR(20) NOT NULL, 
	Notes VARCHAR(MAX)
)
INSERT INTO RoomStatus (RoomStatus, Notes) VALUES
('Free', 'CHECK1'),
('Occupied', 'CHECK2'),
('For cleaning', 'CHECK2')
--SELECT * FROM RoomStatus

CREATE TABLE RoomTypes --PRIMARY KEY? SHOULD WE ADD Id?
(
	RoomType VARCHAR(20) NOT NULL, 
	Notes VARCHAR(MAX)
)
INSERT INTO RoomTypes (RoomType, Notes) VALUES
('APPARTMENT', 'CHECK1'),
('TWO BEDROOM', 'CHECK2'),
('ONE BEDROOM', 'CHECK3')
--SELECT * FROM RoomTypes

CREATE TABLE BedTypes --PRIMARY KEY? SHOULD WE ADD Id?
(
	BedType VARCHAR(20) NOT NULL, 
	Notes VARCHAR(MAX)
)
INSERT INTO BedTypes (BedType, Notes) VALUES
('KING SIZE', 'CHECK1'),
('DOUBLE', 'CHECK2'),
('SINGLE', 'CHECK3')
--SELECT * FROM BedTypes

CREATE TABLE Rooms 
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(20) NOT NULL, 
	BedType VARCHAR(20) NOT NULL, 
	Rate INT, 
	RoomStatus VARCHAR(20) NOT NULL, 
	Notes VARCHAR(MAX)
)
INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(100, 'APPARTMENT', 'KING SIZE', 1, 'Free', 'HIGH PRICE'),
(210, 'TWO BEDROOM', 'DOUBLE', 2, 'Occupied', 'AVG PRICE'),
(320, 'ONE BEDROOM', 'SINGLE', 3, 'For cleaning', 'LOW PRICE')
--SELECT * FROM Rooms

CREATE TABLE Payments 
(
	Id INT PRIMARY KEY, 
	EmployeeId INT NOT NULL, 
	PaymentDate DATETIME NOT NULL, 
	AccountNumber INT NOT NULL, 
	FirstDateOccupied DATETIME NOT NULL, 
	LastDateOccupied DATETIME NOT NULL, 
	TotalDays INT NOT NULL, --Will calculate it later
	AmountCharged DECIMAL(15,2), --Not type MONEY
	TaxRate INT, 
	TaxAmount INT, --DECIMAL(15,2)?
	PaymentTotal DECIMAL(15,2), 
	Notes VARCHAR(MAX)
)
INSERT INTO Payments(Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(12456, 1, '01/12/2020',120, '01/14/2020', '01/16/2020', 2, 200, 20, 40, 240, NULL),
(12457, 2, '01/18/2020',121, '01/22/2020', '01/26/2020', 4, 300, 20, 60, 360, 'NOTE1'),
(12458, 3, '01/20/2020',123, '01/21/2020', '01/22/2020', 1, 150, 20, 30, 180, 'NOTE2')
--SELECT * FROM Payments

CREATE TABLE Occupancies 
(
	Id INT PRIMARY KEY, 
	EmployeeId INT NOT NULL, 
	DateOccupied DATETIME NOT NULL, 
	AccountNumber INT NOT NULL, 
	RoomNumber INT NOT NULL, 
	RateApplied INT, 
	PhoneCharge DECIMAL(15,2), 
	Notes VARCHAR(MAX)
)
INSERT INTO Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, 1, GETDATE(), 120, 100, 1, 20, NULL),
(2, 2, GETDATE(), 121, 210, 2, 5.50, 'NOTE1'),
(3, 3, GETDATE(), 123, 320, 3, 0, 'NOTE2')
--SELECT * FROM Occupancies

--16. Create SoftUniIntro Database --RENAMED FROM SoftUni TO SoftUniIntro, CAUSE WE WILL MAKE ANOTHER BASE WITH NAME SoftUni
--Create bigger database called SoftUniIntro. You will use same database in the future tasks. It should hold information about
--•	Towns (Id, Name)
--•	Addresses (Id, AddressText, TownId)
--•	Departments (Id, Name)
--•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
--Id columns are auto incremented starting from 1 and increased by 1 (1, 2, 3, 4…). Make sure you use appropriate data types for each column. Add primary and foreign keys as constraints for each table. Use only SQL queries. Consider which fields are always required and which are optional.

CREATE DATABASE SoftUniIntro

USE SoftUniIntro
CREATE TABLE Towns 
(
	Id INT PRIMARY KEY IDENTITY, --It is not null as it is IDENTITY(1,1) i.e. starts from 1
	Name VARCHAR(90) NOT NULL
)
CREATE TABLE Addresses 
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(200) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)
CREATE TABLE Departments 
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)
CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(90) NOT NULL,
	MiddleName VARCHAR(90),
	LastName VARCHAR(90),
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments (Id) NOT NULL,
	HireDate DATETIME NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses (Id)
)
-- 17. Backup Database!!!!!!!!!!!!!!!!!!!!!!!!!! SHOULD DO
--Backup the database SoftUniIntro from the previous tasks into a file named “SoftUniIntro-backup.bak”. Delete your database from SQL Server Management Studio. Then restore the database from the created backup.
--Hint: https://support.microsoft.com/en-gb/help/2019698/how-to-schedule-and-automate-backups-of-sql-server-databases-in-sql-se

-- 18. Basic Insert
--Use the SoftUniIntro database and insert some data using SQL queries.
--•	Towns: Sofia, Plovdiv, Varna, Burgas
--•	Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance
--•	Employees:
--Name	Job Title	Department	Hire Date	Salary
--Ivan Ivanov Ivanov	.NET Developer	Software Development	01/02/2013	3500.00
--Petar Petrov Petrov	Senior Engineer	Engineering	02/03/2004	4000.00
--Maria Petrova Ivanova	Intern	Quality Assurance	28/08/2016	525.25
--Georgi Teziev Ivanov	CEO	Sales	09/12/2007	3000.00
--Peter Pan Pan	Intern	Marketing	28/08/2016	599.88
USE SoftUniIntro
INSERT INTO Towns VALUES
('Sofia'),
('Plovdiv'), 
('Varna'),
('Burgas')
--SELECT * FROM Towns
INSERT INTO Departments VALUES
('Engineering'), 
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')
--SELECT * FROM Departments
INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',4,'2/1/2013',3500),
('Petar','Petrov','Petrov','Senior Engineer',1,'3/2/2004',4000),
('Maria','Petrova','Ivanova','Intern',5,'8/28/2016',525.25),
('Georgi','Teziev','Ivanov','CEO',2,'12/9/2007',3000),
('Peter','Pan','Pan','Intern',3,'8/28/2016',599.88)
--SELECT * FROM Employees

--19. Basic Select All Fields
--Use the SoftUniIntro database and first select all records from the Towns, then from Departments and finally from Employees table. Use SQL queries and submit them to Judge at once. Submit your query statements as Prepare DB & Run queries.
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees
--20. Basic Select All Fields and Order Them
--Modify queries from previous problem by sorting:
--•	Towns - alphabetically by name
--•	Departments - alphabetically by name
--•	Employees - descending by salary
--Submit your query statements as Prepare DB & Run queries.
SELECT * FROM Towns
ORDER BY Name ASC

SELECT * FROM Departments
ORDER BY Name ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--21. Basic Select Some Fields
--Modify queries from previous problem to show only some of the columns. For table:
--•	Towns – Name
--•	Departments – Name
--•	Employees – FirstName, LastName, JobTitle, Salary
--Keep the ordering from the previous problem. Submit your query statements as Prepare DB & Run queries.

SELECT Name FROM Towns
ORDER BY Name ASC

SELECT Name FROM Departments
ORDER BY Name ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--22. Increase Employees Salary
--Use SoftUniIntro database and increase the salary of all employees by 10%. Then show only Salary column for all in the Employees table. Submit your query statements as Prepare DB & Run queries.
UPDATE Employees
SET Salary = Salary * 1.1
SELECT Salary FROM Employees

--23. Decrease Tax Rate
--Use Hotel database and decrease tax rate by 3% to all payments. Then select only TaxRate column from the Payments table. Submit your query statements as Prepare DB & Run queries.
USE Hotel
UPDATE Payments
SET TaxRate = TaxRate * (1 - 0.03)
SELECT TaxRate FROM Payments
--24. Delete All Records
--Use Hotel database and delete all records from the Occupancies table. Use SQL query. Submit your query statements as Run skeleton, run queries & check DB.
USE Hotel
DELETE FROM Occupancies
--SELECT * FROM Occupancies