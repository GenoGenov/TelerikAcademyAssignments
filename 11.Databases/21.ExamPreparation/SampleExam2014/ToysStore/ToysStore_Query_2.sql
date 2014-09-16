use ToyStore
GO

CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT m.Name, COUNT(t.Id) AS [Toys in age range 5<=x<=10] FROM Manufacturer m
INNER JOIN Toys t
ON t.ManufacturerId=m.Id
INNER JOIN AgeRange a
ON t.AgeRangeId=a.Id
WHERE a.MinYears>=5 AND a.MaxYears<=10
GROUP BY m.Name
