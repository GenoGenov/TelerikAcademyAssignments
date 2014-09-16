use ToyStore
GO

SELECT Name, Type, Price FROM Toys
WHERE Type LIKE '%s%' AND Price>10
ORDER BY Price