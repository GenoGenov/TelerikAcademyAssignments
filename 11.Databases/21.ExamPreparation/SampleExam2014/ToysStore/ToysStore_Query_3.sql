use ToyStore
GO

CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT t.Name, t.Price, t.Color FROM Toys t
INNER JOIN ToysCategories tc
ON t.Id=tc.ToyId
INNER JOIN Categories c
ON c.Id=tc.CategoryId
WHERE c.Name = 'boys'