IF 
(EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @CarId AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @CarId)) 
BEGIN RAISERROR ('Car not found.',16, 1) END
ELSE


UPDATE dbo.Cars 
SET IsActive = 0 
WHERE dbo.Cars.Id = @carId AND IsActive = 1;