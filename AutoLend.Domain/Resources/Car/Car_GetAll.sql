SELECT 
	Cars.Id, Brands.BrandName, Models.ModelName, Cars.Year, Cars.LicensePlate, Cars.IsAvailable
FROM dbo.Cars as Cars 
INNER JOIN dbo.Models ON Cars.ModelId = dbo.Models.Id
INNER JOIN dbo.Brands ON Models.BrandId = dbo.Brands.Id
WHERE IsActive = 1;