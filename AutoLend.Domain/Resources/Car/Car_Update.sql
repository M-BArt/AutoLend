IF 
(EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @Id AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Cars WHERE Id = @Id)) 
BEGIN RAISERROR ('Car not found.',16, 1) END
ELSE

IF NOT EXISTS (SELECT * FROM dbo.Models WHERE ModelName LIKE '%' + @ModelName + '%')
BEGIN
    RAISERROR ('Model not found.', 16, 1);
END

UPDATE CA
	SET 
		CA.year			= COALESCE(NULLIF(@Year, ''), CA.year), 
		CA.ModelId		= COALESCE((SELECT id FROM dbo.Models WHERE Models.ModelName LIKE '%' + NULLIF(@ModelName, '') + '%'), CA.ModelId),
		CA.LicensePlate	= COALESCE(NULLIF(@LicensePlate, ''), CA.LicensePlate),
		CA.IsAvailable	= COALESCE(@IsAvailable, CA.IsAvailable)
	
	FROM dbo.Cars				AS CA 
		INNER JOIN dbo.Models	AS M	ON C.ModelId = M.id
	
	WHERE 
			CA.Id = 1 
		AND IsActive = 1;