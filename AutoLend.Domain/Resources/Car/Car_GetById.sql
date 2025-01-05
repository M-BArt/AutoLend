IF 
(EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @CarId AND IsActive = 0)) 
OR (NOT EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @CarId)) 
BEGIN RAISERROR ('Car not found.',16, 1) END
ELSE

SELECT 
	CA.Id, 
	B.BrandName, 
	M.ModelName, 
	CA.Year, 
	CA.LicensePlate, 
	CA.IsAvailable

FROM dbo.Cars				AS CA 
	INNER JOIN dbo.Models	AS M  ON CA.ModelId = M.Id
	INNER JOIN dbo.Brands	AS B  ON M.BrandId = B.Id

WHERE 
		CA.Id = @carId 
	AND CA.IsActive = 1
	AND M.IsActive = 1;
