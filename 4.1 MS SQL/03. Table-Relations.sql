--Lab 1. Creating a test database
CREATE DATABASE CoursesTest
--Lab 2. Making a test table with all info in it - so we can rebuild it later to improve it ACCORDING THE NORMAL FORMS OF THE DATABASE. Creating the table with all information about students, cources
USE CoursesTest
CREATE TABLE Students
(

	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	FacultyNumber CHAR(6) NOT NULL,
	Photo VARBINARY(MAX), --по-добре е тук да стои линк, а не самата снимка
	DateOfEnlistment DATE, 
	Cources NVARCHAR(500)
)
INSERT INTO Students VALUES
('Niki', 'F12345', NULL, NULL, 'C# (Sofia), Phyton (Plovdiv) HTML (Ruse)'),
('Stoyan', 'F12346', NULL, NULL, 'Phyton (Plovdiv), PHP (Varna)'),
('Pesho', 'F12347', NULL, NULL, 'PHP (Varna), C# (Sofia)')
--Lab 3. Drop table Students and create it again using UNIQUE for FacultyNumber
CREATE TABLE Students
(

	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	FacultyNumber CHAR(6) NOT NULL UNIQUE,
	Photo VARBINARY(MAX), --по-добре е тук да стои линк, а не самата снимка
	DateOfEnlistment DATE, 
	Cources NVARCHAR(500)
)
--Lab 4. Create table for towns and fill some data in it
CREATE TABLE Towns
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) UNIQUE
)
INSERT INTO Towns ([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Ruse'),
('Stara Zagora')

--Lab 5. Create table for courses and fill some data in it
CREATE TABLE Courses
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	TownId INT REFERENCES Towns(Id)
	--the longer version of the previous line is: 
	--TownId INT FOREIGN KEY REFERENCES Towns(Id)
	--It can be made as a constrain too and it is the same as above - this is the syntacsis and it allows to have PK and FK, which are made of more than one column (naming as we wish as well - not an automatically given name):
	--CONSTRAINT FK_Course_Towns
	--FOREIGN KEY (TownId) --FOREIGN KEY (TownId, , , )
	--REFERENCES Towns(Id) --REFERENCES Towns(Id, , )
)
--If we have already created a table and want to make a foreign key, we can do it like this:
--ALTER TABLE Courses
--ADD FOREIGN KEY (TownId)
--	REFERENCES Towns (Id)
INSERT INTO Courses ([Name], TownId) VALUES
('C#', 1),
('Phyton', 2),
('PHP', 3),
('HTML', 4),
('CSS', 1)

--Lab 6. Create table for relation between courses and students (many to many relation) and fill some data in it. We can make a new primary key Id, but if the relation between the two PKs is unique, we can make a primary key from them:
--CREATE TABLE StudentsCourses
--(
--	StudentId INT NOT NULL,
--	CourseId INT,
--	Mark DECIMAL(3,2),
--	CONTRAINT PK_StudentsCourses
--		PRIMARY KEY(StudentId, CourseId),
--	CONSTRAINT FK_StudentsCourses_Students
--		FOREIGN KEY (StudentId)
--		REFERENCES Students (Id),
--	CONSTRAIN FK_FK_StudentsCourses_Courses
--		FOREIGN KEY (CourseId)
--		REFERENCES Courses (Id)
--)
--this is much more shorter and the same as above:
CREATE TABLE StudentsCourses
(
	StudentId INT REFERENCES Students (Id),
	CourseId INT REFERENCES Courses (Id),
	Mark DECIMAL(3,2),
	CONSTRAINT PK_StudentsCourses
		PRIMARY KEY(StudentId, CourseId)
)
INSERT INTO StudentsCourses VALUES
(1, 1, 5.50),
(1, 2, 5.00),
(1, 4, 6.00),
(2, 2, 5.50),
(2, 3, 4.50),
(3, 3, 5.50),
(3, 1, 4.50)

--Lab 7. Delete column Cources in table Students, which wasn't normalized
ALTER TABLE Students
DROP COLUMN Cources
--Lab 8. Join two tables and take all columns from them and having some condition
SELECT * 
	FROM Courses
	JOIN Towns 
		ON Courses.TownId = Towns.Id
	WHERE LEFT(Courses.Name, 1) = 'C'
--Lab 9. Join more tables and take columns from them
SELECT * -- s.Name AS StudentName, c.Name AS CourseName, t.Name AS TownName, sc.Mark
	FROM StudentsCourses AS sc
	JOIN Courses AS c ON sc.CourseId = c.Id
	JOIN Students AS s ON sc.StudentId = s.Id
	JOIN Towns AS t ON c.TownId = t.Id
	--WHERE LEFT(c.Name, 1) = 'C'
--Lab 10. Join two tables from DB - exercise: Peaks in Rila
--Use database "Geography". Report all peaks for "Rila" mountain.
--Report includes mountain's name, peak's name and also peak's elevation
--Peaks should be sorted by elevation descending
USE Geography
SELECT m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m
		ON p.MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
	ORDER BY p.Elevation DESC

--Lab 11. Delete - it doesn't allow us to delete, cause we have references to this row 
USE CoursesTest
DELETE FROM Courses
	WHERE [Name] = 'PHP'
--Lab 12.1 Cascade Delete. We don't use cascade delete when we have logical deletion like this.
--It's not good to delete data from the tables, better use logical deletion.
ALTER TABLE Courses
ADD IsDeleted BIT DEFAULT 0 NOT NULL

UPDATE Courses
	SET IsDeleted = 1
	WHERE [NAME] = 'PHP'
--ALTER TABLE Courses
--drop column IsDeleted 
--if we have logically deleted - we always should have where clause:
SELECT * 
	FROM Courses
	WHERE IsDeleted = 0 --it works - why the program undeline it as not valid?

--Lab 12.2 Cascade Delete/ Update. When we create a table we add CASCADE. This table is already created, but to show the sintaxis: 
CREATE TABLE StudentsCourses
(
	StudentId INT NOT NULL,
	CourseId INT,
	Mark DECIMAL(3,2),
	CONTRAINT PK_StudentsCourses
		PRIMARY KEY(StudentId, CourseId),
	CONSTRAINT FK_StudentsCourses_Students
		FOREIGN KEY (StudentId)
		REFERENCES Students (Id) ON DELETE CASCADE, -- ON UPDATE CASCADE
	CONSTRAIN FK_FK_StudentsCourses_Courses
		FOREIGN KEY (CourseId)
		REFERENCES Courses (Id) ON DELETE CASCADE -- ON UPDATE CASCADE
)
--We can ALTER TABLE to add cascade too - first we delete the FK and then create it again with cascade.


--Exercises
--Ex 1. One-To-One Relationship
--Create two tables as follows. Use appropriate data types.
--Persons		Passports
--PersonID	FirstName	Salary	PassportID		PassportID	PassportNumber
--1			Roberto		43300.00	102			101	N34FG21B
--2			Tom			56100.00	103			102	K65LO4R7
--3			Yana		60200.00	101			103	ZE657QP2
--Insert the data from the example above.
--Alter the Persons table and make PersonID a primary key. Create a foreign key between Persons and Passports by using PassportID column.

CREATE DATABASE TableRelations
USE TableRelations
CREATE TABLE Passports
(
	PassportID INT UNIQUE NOT NULL,
	PassportNumber VARCHAR(8) UNIQUE NOT NULL
)

CREATE TABLE Persons
(
	PersonID INT UNIQUE NOT NULL, 
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(10,2),
	PassportID INT UNIQUE NOT NULL 
)
INSERT INTO Passports VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')
INSERT INTO Persons VALUES
(1,'Roberto',43300,102),
(2,'Tom',56100,103),
(3,'Yana',60200,101)

ALTER TABLE Passports
ADD PRIMARY KEY (PassportID)

ALTER TABLE Persons
ADD PRIMARY KEY (PersonID)
ALTER TABLE Persons
ADD FOREIGN KEY (PassportID) REFERENCES Passports (PassportID)

--Ex 2. One-To-Many Relationship
--Create two tables as follows. Use appropriate data types.
--Models		Manufacturers
--ModelID	Name	ManufacturerID		ManufacturerID	Name	EstablishedOn
--101		X1			1				1  				BMW		07/03/1916
--102		i6			1				2				Tesla	01/01/2003
--103		Model S		2				3				Lada	01/05/1966
--104		Model X		2		
--105		Model 3		2		
--106		Nova		3		
--Insert the data from the example above. Add primary keys and foreign keys.

CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATE
)
CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY (101,1),
	[Name] VARCHAR(50) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers (ManufacturerID)
)
INSERT INTO Manufacturers VALUES
('BMW','07/03/1916'), --DATE SHOULD BE '1916-07-03', BUT FOR JUDGE IT'S OK LIKE THIS FOR NOW
('Tesla','01/01/2003'),
('Lada','01/05/1966')

INSERT INTO Models VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)

--Ex 3. Many-To-Many Relationship
--Create three tables as follows. Use appropriate data types.
--Students					Exams		StudentsExams
--StudentID	Name		ExamID	Name		StudentID	ExamID
--1  			Mila        101	SpringMVC			1	101
--2			Toni		102	Neo4j				1	102
--3			Ron			103	Oracle 11g			2	101
--												3	103
--												2	102
--												2	103
--Insert the data from the example above.
--Add primary keys and foreign keys. Have in mind that table StudentsExams should have a composite primary key.

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,
	CONSTRAINT PK_StudentsExams 
	PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_PK_StudentsExams_Students
	FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_Exams
	FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)
INSERT INTO Students VALUES
('Mila'),                                
('Toni'),
('Ron')

INSERT INTO Exams VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams VALUES
(1,	101),
(1,	102),
(2,	101),
(3,	103),
(2,	102),
(2,	103)

--Ex 4.	Self-Referencing 
--Create a single table as follows. Use appropriate data types.
--Teachers
--TeacherID	Name	ManagerID
--101	John	NULL
--102	Maya	106
--103	Silvia	106
--104	Ted	105
--105	Mark	101
--106	Greta	101
--Insert the data from the example above. Add primary keys and foreign keys. The foreign key should be between ManagerId and TeacherId.

CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
('John',NULL),
('Maya',106),
('Silvia',106),
('Ted',105),
('Mark',101),
('Greta',101)

--Ex 5.	Online Store Database
--Create a new database and design the following structure: given database diagram
CREATE DATABASE OnlineStore 
USE OnlineStore
CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
	CONSTRAINT PK_OrderItems
	PRIMARY KEY (OrderID,ItemID),
)

--Ex 6.	University Database
--Create a new database and design the following structure: given database diagram
CREATE DATABASE University
USE University
CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50) NOT NULL
)
CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)
CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(15,2),
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)
CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	CONSTRAINT PK_StudentSubject
	PRIMARY KEY (StudentID, SubjectID)
)
--Ex 7. SoftUni Design
--Create an E/R Diagram of the SoftUni Database. There are some special relations you should check out: Employees are self-referenced (ManagerID) and Departments have One-to-One with the Employees (ManagerID) while the Employees have One-to-Many (DepartmentID). You might find it interesting how it looks on the diagram.
--Ex 8.	Geography Design
--Create an E/R Diagram of the Geography Database.
--Ex 9.	*Peaks in Rila
--Display all peaks for "Rila" mountain. Include:
--Х	MountainRange
--Х	PeakName
--Х	Elevation
--Peaks should be sorted by elevation descending.
USE Geography
SELECT MountainRange, PeakName,  Elevation
	FROM Peaks p
	JOIN Mountains m ON p.MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
	ORDER BY Elevation DESC