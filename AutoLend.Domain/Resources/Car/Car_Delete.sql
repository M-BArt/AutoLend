IF 
(EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @CarId AND IsActive = 0)) 
OR (NOT EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @CarId AND dbo.Cars.IsActive = 1)) 
BEGIN RAISERROR ('Car not found.',16, 1) END
ELSE


UPDATE CA
SET 
	IsActive = 0 
FROM 
	dbo.Cars AS CA
WHERE 
	CA.Id = @carId 
AND IsActive = 1;