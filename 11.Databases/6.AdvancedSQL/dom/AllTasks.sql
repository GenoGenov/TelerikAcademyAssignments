use TelerikAcademy;
GO
--Below are all queries for all tasks. Just uncomment(Ctrl+K,Ztrl+U) the query that you want to execute

--1.Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.
	--SELECT FirstName+' '+LastName AS [Full Name], Salary FROM Employees
	--WHERE Salary =
	--(SELECT MIN(Salary) FROM Employees)

--2.Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
	--SELECT FirstName+' '+LastName AS [Full Name], Salary FROM Employees
	--	WHERE Salary <=
	--	(SELECT MIN(Salary)*1.10 FROM Employees)
	--	ORDER By Salary

--3.Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.
	--SELECT e.FirstName+' '+e.LastName AS [Full Name], e.Salary, d.Name
	--FROM Employees e
	--INNER JOIN Departments d
	--ON d.DepartmentID=e.DepartmentID
	--WHERE e.Salary=
	--(SELECT MIN(Salary) FROM Employees
	--WHERE e.DepartmentID = DepartmentID)

--4.Write a SQL query to find the average salary in the department #1.
	--SELECT AVG(Salary) AS AvgSalary FROM Employees
	--WHERE DepartmentID=1

--5.Write a SQL query to find the average salary  in the "Sales" department.
	--SELECT AVG(Salary) FROM Employees
	--WHERE DepartmentID=
	--(SELECT DepartmentID FROM Departments
	--WHERE Name='Sales')

--6.Write a SQL query to find the number of employees in the "Sales" department.
	--SELECT COUNT(*) FROM Employees
	--WHERE DepartmentID=
	--(SELECT DepartmentID FROM Departments
	--WHERE Name='Sales')

--7.Write a SQL query to find the number of all employees that have manager.
	--SELECT COUNT(*) FROM Employees
	--WHERE ManagerID IS NOT NULL

--8.Write a SQL query to find the number of all employees that have no manager.
	--SELECT COUNT(*) FROM Employees
	--WHERE ManagerID IS NULL

--9.Write a SQL query to find all departments and the average salary for each of them
	--SELECT d.Name, AVG(e.Salary) AS [Average Salary] FROM Departments d
	--INNER JOIN Employees e
	--ON e.DepartmentID=d.DepartmentID
	--GROUP BY d.Name

--10.Write a SQL query to find the count of all employees in each department and for each town.
	--SELECT t.Name AS [Town],d.Name AS[Department], COUNT(*) AS[Employees Count] FROM Employees e
	--INNER JOIN Departments d
	--ON e.DepartmentID=d.DepartmentID
	--INNER JOIN Addresses a
	--ON a.AddressID=e.AddressID
	--INNER JOIN Towns t
	--ON t.TownID=a.TownID
	--GROUP BY t.Name,d.Name

--11.Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
	--SELECT m.FirstName+' '+m.LastName AS [Manager with 5 employees] FROM Employees m
	--INNER JOIN Employees e
	--ON e.ManagerID=m.EmployeeID
	--GROUP BY m.FirstName, m.LastName HAVING COUNT(m.EmployeeID)=5

--12.Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
	--SELECT e.FirstName+' '+e.LastName AS[Employee], COALESCE(m.FirstName+' '+m.LastName, 'No manager') FROM Employees e
	--LEFT OUTER JOIN Employees m
	--ON m.EmployeeID=e.ManagerID
	--ORDER By m.FirstName, m.LastName

--13.Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
	--SELECT FirstName FROM Employees
	--WHERE LEN(FirstName)=5

--14.Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.
	--SELECT CONVERT(VARCHAR(8), GETDATE(), 2)+CONVERT(VARCHAR(12), GETDATE(), 114)

--15.Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--Choose appropriate data types for the table fields.
--Define a primary key column with a primary key constraint.
--Define the primary key column as identity to facilitate inserting records.
--Define unique constraint to avoid repeating usernames.
--Define a check constraint to ensure the password is at least 5 characters long.
	--CREATE TABLE Users(
	--userID INT IDENTITY,
	--username NVARCHAR(50),
	--userpass NVARCHAR(50),
	--fullname NVARCHAR(50),
	--logname NVARCHAR(50),
	--lastlogin DATETIME,
	--CONSTRAINT PK_Users PRIMARY KEY(userID),
	--CONSTRAINT UN_Username UNIQUE(username),
	--CONSTRAINT LONGINESS_PASS CHECK(LEN(userpass)>=5)

	--)
	--GO

--16.Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. Test if the view works correctly.
	--CREATE VIEW Logged_In_Today AS
	--SELECT username,
	-- lastlogin,
	--  'Last '+CONVERT(nvarchar(5),DATEPART(hour,lastlogin)-DATEPART(hour,GETDATE()))+'hours and '+CONVERT(nvarchar(5),DATEPART(minute,lastlogin)-DATEPART(minute,GETDATE()))+' minutes ago' AS TimeElapsed
	--   FROM Users
	--WHERE year(lastlogin)=year(GETDATE()) AND month(lastlogin)=month(GETDATE()) AND day(lastlogin)=day(GETDATE())
	--GO

	--I remembered that DATEDIFF exists too late :/




	--INSERT INTO Users
	-- VALUES('pencho','12344444','pencho penchev','penata123','2014-08-24 12:12:12')
	--GO

	-- INSERT INTO Users
	-- VALUES('mencho','124444434','pencho penchev','penata123','2012-08-24 12:12:12')
	--GO

	-- INSERT INTO Users
	-- VALUES('gencho','124444434','pencho penchev','penata123','2014-08-24 09:12:12')
	--GO

	-- INSERT INTO Users
	-- VALUES('nencho','144444234','pencho penchev','penata123','2014-08-24 12:02:12')
	--GO

	--SELECT * FROM Logged_In_Today
	--GO
--17.Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--Define primary key and identity column.
	--CREATE TABLE Groups(
	--groupID INT IDENTITY,
	--Name NVARCHAR(50),
	--CONSTRAINT PK_Group PRIMARY KEY(groupID),
	--CONSTRAINT UN_Name UNIQUE(Name),

	--)
	--GO

--18.Write a SQL statement to add a column GroupID to the table Users.
--Fill some data in this new column and as well in the Groups table.
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

--ALTER TABLE Users
--ADD GroupID INT
--GO

--UPDATE USERS
--SET GroupID=userID;
--GO

--INSERT INTO Groups
--VALUES('Hackers'),('Losers'),('Players')
--GO

--ALTER TABLE USERS
--ADD CONSTRAINT FK_USERS_GROUPS FOREIGN KEY(GroupID) REFERENCES Groups(GroupID)
--GO

--19.Write SQL statements to insert several records in the Users and Groups tables.
--INSERT INTO Users
--VALUES('gnMincho','1111111111','alabala aalabala','alala','2014-08-25 00:05:22',2),
--('gnPincho','1111111111','alabala aalabala','alala','2014-08-25 00:05:22',2),
--('gnZincho','1111111111','alabala aalabala','alala','2014-08-25 00:05:22',2)
--GO

--INSERT INTO Groups
--VALUES('Fkers'),('Pimps'),('Wh*res')
--GO

--20.Write SQL statements to delete some of the records from the Users and Groups tables.
--DELETE FROM Groups
--WHERE Name='Wh*res'
--GO

--DELETE FROM Users
--WHERE username='gnZincho'
--GO

--21.Write SQL statements to update some of the records in the Users and Groups tables.
--UPDATE Users
--SET userpass='123456'
--WHERE username='gnPincho'
--GO

--22.Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--Combine the first and last names as a full name.
--For username use the first letter of the first name + the last name (in lowercase).
--Use the same for the password, and NULL for last login time.
	--INSERT INTO Users(username,userpass,fullname)
	--SELECT LOWER(SUBSTRING(FirstName,1,3)+LastName),
	--LOWER(SUBSTRING(FirstName,1,3)+LastName),
	--FirstName+LastName 
	--FROM Employees
	--GO

--23.Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
	--UPDATE Users
	--SET lastlogin='20090404'
	--WHERE username LIKE 'g%' --just so the next could be tested :)
	--GO

	--UPDATE Users
	--SET userpass=NULL
	--WHERE lastlogin<'20100310'
	--GO

--24.Write a SQL statement that deletes all users without passwords (NULL password).
	--DELETE FROM Users
	--WHERE userpass IS NULL

--25.Write a SQL query to display the average employee salary by department and job title.
	--SELECT d.Name  AS [Department], e.JobTitle AS[Job Title], AVG(e.Salary) AS[Average Salary] FROM Departments d
	--INNER JOIN Employees e
	--ON e.DepartmentID=d.DepartmentID
	--GROUP BY d.Name, e.JobTitle
	--ORDER BY [Average Salary] DESC

--26.Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
	--SELECT e.FirstName+' '+e.LastName AS[Employee Name], d.Name  AS [Department], e.JobTitle AS[Job Title], MIN(e.Salary) AS[Minimal Salary] FROM Departments d
	--INNER JOIN Employees e
	--ON e.DepartmentID=d.DepartmentID
	--GROUP BY e.FirstName,e.LastName,d.Name, e.JobTitle
	--ORDER BY [Minimal Salary] DESC

--27.Write a SQL query to display the town where maximal number of employees work.
	--SELECT TOP 1 t.Name, COUNT(e.EmployeeID) AS [Employees Count] FROM Towns t
	--INNER JOIN Addresses a
	--ON a.TownID=t.TownID
	--INNER JOIN Employees e
	--ON e.AddressID=a.AddressID
	--GROUP BY t.Name
	--ORDER BY [Employees Count] DESC

--28.Write a SQL query to display the number of managers from each town.
	--SELECT t.Name, COUNT(e.EmployeeID) AS [Managers Count] FROM Towns t
	--INNER JOIN Addresses a
	--ON a.TownID=t.TownID
	--INNER JOIN Employees e
	--ON e.AddressID=a.AddressID
	--WHERE EXISTS
	--(SELECT ManagerID FROM Employees
	--WHERE ManagerID=e.EmployeeID)
	--GROUP BY t.Name

--29.Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--Don't forget to define  identity, primary key and appropriate foreign key. 
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--For each change keep the old record data, the new record data and the command (insert / update / delete).

	--CREATE TABLE WorkHours(
	--WorkID INT PRIMARY KEY IDENTITY,
	--DateCreated DATETIME,
	--Task NVARCHAR(50),
	--HoursWorked INT,
	--Comments NVARCHAR(100),
	--EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID)
	--)
	--GO
	
	--CREATE TABLE WorkHoursLogs(
	--LogID INT PRIMARY KEY IDENTITY,
	--DateLogged DATETIME,
	--Command NVARCHAR(20),
	--DateOfWork DATETIME,
	--TaskName NVARCHAR(50),
	--HoursWorked INT,
	--Comments NVARCHAR(100),
	--)
	--GO

--CREATE TRIGGER OnInsertWorkHours
-- ON WorkHours
-- FOR INSERT
--AS
--INSERT INTO WorkHoursLogs(DateLogged, Command, DateOfWork, TaskName, HoursWorked, Comments)
--    SELECT GETDATE(), 
--		   'INSERT', 
--		   DateCreated, 
--		   Task, 
--		   HoursWorked,
--		   Comments
--      FROM inserted
--GO

--CREATE TRIGGER OnUpdateWorkHours
-- ON WorkHours
-- FOR UPDATE
--AS
--INSERT INTO WorkHoursLogs(DateLogged, Command, DateOfWork, TaskName, HoursWorked, Comments)
--    SELECT GETDATE(), 
--		   'UPDATE', 
--		   DateCreated, 
--		   Task, 
--		   HoursWorked,
--		   Comments
--      FROM deleted

--INSERT INTO WorkHoursLogs(DateLogged, Command, DateOfWork, TaskName, HoursWorked, Comments)
--    SELECT GETDATE(), 
--		   'UPDATE', 
--		   DateCreated, 
--		   Task, 
--		   HoursWorked,
--		   Comments
--      FROM inserted
--GO

--CREATE TRIGGER OnDeleteWorkHours
-- ON WorkHours
-- FOR DELETE
--AS
--INSERT INTO WorkHoursLogs(DateLogged, Command, DateOfWork, TaskName, HoursWorked, Comments)
--    SELECT GETDATE(), 
--		   'DELETE', 
--		   DateCreated, 
--		   Task, 
--		   HoursWorked,
--		   Comments
--      FROM deleted


--INSERT INTO WorkHours
--VALUES(GETDATE(),'Kopame',4,'Golqma Jega..',1)
--GO

--UPDATE WorkHours
--SET
--	Task='Oshte kopame'
--GO

--DELETE FROM WorkHours
--WHERE Task='Oshte kopame'
--GO

--30.Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. 
-- At the end rollback the transaction.

--BEGIN TRAN
--ALTER TABLE Departments
--DROP CONSTRAINT FK_Departments_Employees
--DELETE FROM Employees
--WHERE DepartmentID = 
--(SELECT DepartmentID FROM Departments
--WHERE Name='Sales')
--ROLLBACK TRAN

--31.Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?
--BEGIN TRAN
--DROP TABLE EmployeesProjects
--ROLLBACK TRAN

--32.Find how to use temporary tables in SQL Server.
--Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.

--CREATE TABLE #EmployeesProjectsTemp (
--EmployeeID int NOT NULL,
--ProjectID int NOT NULL,
--CONSTRAINT PK_EmployeesProjectsTemp PRIMARY KEY CLUSTERED (EmployeeID ASC, ProjectID ASC));

--INSERT INTO #EmployeesProjectsTemp
--SELECT * FROM EmployeesProjects

--DROP TABLE EmployeesProjects

--CREATE TABLE EmployeesProjects(
--  EmployeeID int NOT NULL,
--  ProjectID int NOT NULL,
--  CONSTRAINT PK_EmployeesProjects PRIMARY KEY CLUSTERED (EmployeeID ASC, ProjectID ASC)
--)
--GO

--INSERT INTO EmployeesProjects
--SELECT * FROM #EmployeesProjectsTemp