SELECT ModelName, BrandName, Year, LicensePlate, IsAvailable 
FROM dbo.Cars 
INNER JOIN dbo.Models ON dbo.Cars.ModelId = dbo.Models.Id
INNER JOIN dbo.Brands ON dbo.Models.BrandId = dbo.Brands.Id
WHERE IsActive = 1
  AND (@ModelName IS NULL OR ModelName LIKE @ModelName + '%')
  AND (@BrandName IS NULL OR BrandName LIKE @BrandName + '%')
  AND (
        (@YearFrom IS NULL AND @YearTo IS NULL)
        OR (@YearFrom IS NOT NULL AND @YearTo IS NULL AND Year >= @YearFrom)
        OR (@YearFrom IS NULL AND @YearTo IS NOT NULL AND Year <= @YearTo)
        OR (Year BETWEEN @YearFrom AND @YearTo)
      )
  AND (@LicensePlate IS NULL OR LicensePlate LIKE @LicensePlate + '%')
  AND (@IsAvailable IS NULL OR IsAvailable = @IsAvailable);