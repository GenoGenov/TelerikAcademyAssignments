use Persons;
GO

--2.Create a stored procedure that accepts a number as a parameter and returns all persons
--- who have more money in their accounts than the supplied number.

--CREATE PROCEDURE usp_GetPersonsWithMoreMoneyThan(@Money MONEY = 0) AS
--SELECT p.FirstName, a.Balance  FROM Persons p
--	INNER JOIN Accounts a
--	ON a.PersonID=p.PersonID
--WHERE a.Balance>@Money
--ORDER BY a.Balance
--GO

--EXEC usp_GetPersonsWithMoreMoneyThan 1000

--3.Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.

--CREATE FUNCTION ufn_CalcInterest(@sum MONEY,@interestRate DECIMAL(18,2), @months INT)
--RETURNS MONEY
--AS
--BEGIN
--RETURN @months*@interestRate*@sum
--END
--GO

--SELECT FirstName,LastName, a.Balance,1.5 AS [Interest Rate],12 AS Months ,dbo.ufn_CalcInterest(a.Balance,1.5,12) AS [Final Sum]
--FROM Persons p
--INNER JOIN Accounts a
--ON a.PersonID=p.PersonID

--4.Create a stored procedure that uses the function from the previous example to give an interest
--- to a person's account for one month. It should take the AccountId and the interest rate as parameters.

	--CREATE PROCEDURE usp_GiveOneMonthInterest(@AccID INT, @InterestRate DECIMAL(18,2))
	--AS
	--UPDATE Accounts
	--SET Balance=dbo.ufn_CalcInterest(Balance,@InterestRate,1)
	--WHERE AccountID=@AccID
	--GO

--SELECT p.FirstName, a.Balance AS[Before Procedure] FROM Persons p
--INNER JOIN Accounts a
--ON a.PersonID=p.PersonID
--WHERE p.PersonID=1
--GO

--EXEC usp_GiveOneMonthInterest 1, 1.5
--GO
--SELECT p.FirstName, a.Balance AS[After Procedure] FROM Persons p
--INNER JOIN Accounts a
--ON a.PersonID=p.PersonID
--WHERE p.PersonID=1
--GO

--5.Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money)
 -- that operate in transactions.

 --	CREATE PROCEDURE usp_WithdrawMoney(@AccID INT, @Sum MONEY)
	--AS
	--DECLARE @Error BIT=0
	--BEGIN TRAN
	--IF((SELECT Balance FROM Accounts WHERE AccountID=@AccID) <@Sum)
	--	BEGIN
	--		ROLLBACK TRAN
	--		SET @Error=1
	--	END
	--ELSE
	--	BEGIN
	--		UPDATE Accounts
	--		SET Balance=Balance-@Sum
	--		WHERE AccountID=@AccID
	--	END
	--IF(@Error=0)
	--BEGIN
	--COMMIT TRAN
	--END
	--GO

	--CREATE PROCEDURE usp_DepositMoney(@AccID INT, @Amount MONEY)
	--AS
	--BEGIN TRAN
	--UPDATE Accounts
	--SET Balance=Balance+@Amount
	--WHERE AccountID=@AccID
	--COMMIT
	--GO

	--SELECT p.FirstName, a.Balance AS[Before Withdrawal] FROM Persons p
	--INNER JOIN Accounts a
	--ON a.PersonID=p.PersonID
	--WHERE p.PersonID=1
	--GO

	--EXEC usp_WithdrawMoney 1, 1500

	--GO
	--SELECT p.FirstName, a.Balance AS[After Withdrawal] FROM Persons p
	--INNER JOIN Accounts a
	--ON a.PersonID=p.PersonID
	--WHERE p.PersonID=1
	--GO

	--SELECT p.FirstName, a.Balance AS[Before Deposit] FROM Persons p
	--INNER JOIN Accounts a
	--ON a.PersonID=p.PersonID
	--WHERE p.PersonID=1
	--GO

	--EXEC usp_DepositMoney 1, 10000

	--GO
	--SELECT p.FirstName, a.Balance AS[After Deposit] FROM Persons p
	--INNER JOIN Accounts a
	--ON a.PersonID=p.PersonID
	--WHERE p.PersonID=1
	--GO

--6.Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--  Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

	--CREATE TABLE Logs(
	--LogID INT PRIMARY KEY IDENTITY,
	--AccountID INT FOREIGN KEY REFERENCES Accounts(AccountID),
	--OldSum MONEY NOT NULL,
	--NewSum MONEY NOT NULL
	--)
	--GO

	--CREATE TRIGGER tr_TownsUpdate ON Accounts FOR UPDATE
	--AS
	--INSERT INTO Logs(AccountID, OldSum, NewSum)
	--  SELECT d.AccountID, d.Balance, i.Balance FROM deleted d, inserted i
	--GO

	--EXEC usp_WithdrawMoney 1, 1500
	
--7.Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name)
 -- and all town's names that are comprised of given set of letters.
 -- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
 --use TelerikAcademy;
 --GO

	--CREATE FUNCTION ufn_StringContainsName(@Str NVARCHAR(50), @Name NVARCHAR(50))
	--RETURNS BIT
	--AS
	--BEGIN
	--DECLARE @i INT
	--DECLARE @matched INT
	--DECLARE @j INT
	--DECLARE @current NVARCHAR(1)
	--SET @j=1
	--SET @matched=0
	--SET @i=1
	--WHILE(LEN(@Name)>=@i)
	--BEGIN
	--SET @current=SUBSTRING(@Name,@i,1)
	--	WHILE(LEN(@Str)>=@j)
	--		BEGIN
	--		IF(@current=SUBSTRING(@Str,@j,1))
	--			BEGIN
	--			SET @matched=@matched+1
	--			BREAK
	--			END
	--		SET @j=@j+1
	--		END
	--SET @i=@i+1
	--SET @j=1
	--END
	--IF(@matched=LEN(@Name))
	--	BEGIN
	--	RETURN 1
	--	END
	--RETURN 0
	--END
	--GO

	 --use TelerikAcademy;
	 --GO

	--CREATE FUNCTION ufn_GetEmployeeAndTownNamesBasedOnString(@Str NVARCHAR(50))
	--RETURNS TABLE
	--AS
	--RETURN (
	--		SELECT COALESCE(e.FirstName, e.MiddleName, e.LastName) AS [Name], t.Name AS [Town Name] FROM Employees e
	--		INNER JOIN Towns t
	--		ON 1=dbo.ufn_StringContainsName(@Str,t.Name)
	--		WHERE 1=dbo.ufn_StringContainsName(@Str,COALESCE(e.FirstName, e.MiddleName, e.LastName))
	--		)
	--GO

	--SELECT * FROM ufn_GetEmployeeAndTownNamesBasedOnString('oistmiahf')

--8.Using database cursor write a T-SQL script that scans all employees and their addresses
--  and prints all pairs of employees that live in the same town.

	-- use TelerikAcademy;
	-- GO

	--DECLARE empCursor CURSOR FOR
	--SELECT e.FirstName, e.LastName, t.Name FROM Employees e
	--INNER JOIN Addresses a
	--ON e.AddressID=a.AddressID
	--INNER JOIN Towns t
	--ON t.TownID=a.TownID

	--OPEN empCursor
	--CREATE TABLE #EmployeesTownsPairs(
	--	FName VARCHAR(50),
	--	LName VARCHAR(50),
	--	TName VARCHAR(50)
	--)
	--DECLARE @firstName VARCHAR(50), @lastName VARCHAR(50), @town VARCHAR(50)
	--FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town

	--WHILE @@FETCH_STATUS = 0
	--BEGIN
 --   INSERT INTO #EmployeesTownsPairs(FName,LName,TName)
	--VALUES(@firstName, @lastName, @town)
 --   FETCH NEXT FROM empCursor 
 --   INTO @firstName, @lastName, @town
	--END

	--CLOSE empCursor
	--DEALLOCATE empCursor

	--SELECT * FROM #EmployeesTownsPairs
	--GROUP BY TName, FName, LName

--9.* Write a T-SQL script that shows for each town a list of all employees that live in it.

--- THE ASSEMBLY  FOR TASK 10 IS HERE !!!!!

	--   CREATE Assembly ua_concat
	--   AUTHORIZATION dbo 
	--   FROM 'D:\TELERIK\TelerikAcademyAssignments\11.Databases\7.Transact-SQL\dom\SQL-Aggregate-Proj.dll'
	--   --- CHANGE THAT TO YOUR PATH !
	--   WITH PERMISSION_SET = SAFE; 
	--GO 
	
	--CREATE AGGREGATE dbo.StrConcat ( 
	
	--    @Value NVARCHAR(MAX)
	
	--) RETURNS NVARCHAR(MAX) 
	--EXTERNAL Name ua_concat.MergeStrings; 
	--GO
	
	---- Enable execution of CLR code 
	--sp_configure 'clr enabled',1
	--GO
	--RECONFIGURE
	--GO

	--USE [TelerikAcademy]
	--GO
	
	--SELECT t.Name AS Town, [dbo].StrConcat(FirstName + ' ' + LastName) AS Employees
	--FROM Employees e
	--INNER JOIN Addresses a ON e.AddressID = a.AddressID
	--INNER JOIN Towns t ON t.TownID = a.TownID
	--GROUP BY t.Name
	--ORDER BY t.Name


--10.Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string
-- that consists of the input strings separated by ','. For example the following SQL statement should return a single string:

---THE ASSEMBLY FOR TASK 10 IS IN THE BEGINNING OF TASK 9 !!! LOOK ABOVE !!!

--SELECT [dbo].StrConcat(FirstName + ' ' + LastName) as Names
--FROM Employees