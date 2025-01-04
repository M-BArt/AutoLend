IF 
(EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @Id AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @Id)) 
BEGIN RAISERROR ('Car not found.',16, 1) END
ELSE

IF NOT EXISTS (SELECT * FROM dbo.Models WHERE ModelName LIKE '%' + @ModelName + '%')
BEGIN
    RAISERROR ('Model not found.', 16, 1);
END

UPDATE Cars
	SET 
	Cars.year = COALESCE(NULLIF(@Year, ''), Cars.year), 
	Cars.ModelId = COALESCE((SELECT id FROM dbo.Models WHERE Models.ModelName LIKE '%' + NULLIF(@ModelName, '') + '%'), Cars.ModelId),
	Cars.LicensePlate = COALESCE(NULLIF(@LicensePlate, ''), Cars.LicensePlate),
	Cars.IsAvailable = COALESCE(@IsAvailable, Cars.IsAvailable)
	FROM dbo.Cars as Cars 
	INNER JOIN dbo.Models ON Cars.ModelId = dbo.Models.id
	WHERE Cars.Id = 1 AND IsActive = 1;