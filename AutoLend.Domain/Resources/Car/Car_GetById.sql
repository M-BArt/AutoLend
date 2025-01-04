IF 
(EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @CarId AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @CarId)) 
BEGIN RAISERROR ('Car not found.',16, 1) END
ELSE

SELECT 
	Cars.Id, Brands.BrandName, Models.ModelName, Cars.Year, Cars.LicensePlate, Cars.IsAvailable
FROM dbo.Cars as Cars 
INNER JOIN dbo.Models ON Cars.ModelId = dbo.Models.Id
INNER JOIN dbo.Brands ON Models.BrandId = dbo.Brands.Id
WHERE Cars.id = @carId AND IsActive = 1;
