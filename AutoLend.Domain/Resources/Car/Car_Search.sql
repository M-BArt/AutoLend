DECLARE @ModelData TABLE (
    ModelId INT
);

INSERT INTO @ModelData (ModelId)
SELECT ModelId
FROM OPENJSON(@json)
WITH (
    ModelId INT '$.ModelId'
);

SELECT 
    M.ModelName, 
    B.BrandName, 
    C.Year, 
    C.LicensePlate, 
    C.IsAvailable 
FROM dbo.Cars as C
INNER JOIN dbo.Models as M ON C.ModelId = M.Id
INNER JOIN dbo.Brands as B ON M.BrandId = B.Id
WHERE 
C.IsActive = 1 
AND M.IsActive = 1
AND B.IsActive = 1
  AND (@text IS NULL OR C.ModelName + ' ' + B.BrandName LIKE '%' + @text + '%')
  AND M.Id IN (SELECT Id FROM @ModelData)
  AND (
        (@YearFrom IS NULL AND @YearTo IS NULL)
        OR (@YearFrom IS NOT NULL AND @YearTo IS NULL AND Year >= @YearFrom)
        OR (@YearFrom IS NULL AND @YearTo IS NOT NULL AND Year <= @YearTo)
        OR (Year BETWEEN @YearFrom AND @YearTo)
      )
  AND (@IsAvailable IS NULL OR IsAvailable = @IsAvailable);