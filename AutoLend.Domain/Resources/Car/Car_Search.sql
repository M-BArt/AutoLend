SET
    @Page = ISNULL(@Page, 1)
SET
    @PageSize = ISNULL(@PageSize, 10)
SET
    @OrderDir = ISNULL(@OrderDir, 1)
SET
    @OrderBy = ISNULL(@OrderBy, 'Name') DECLARE @OrderDesc VARCHAR(10) = CASE
        WHEN @OrderDir < 0 THEN 'DESC'
        WHEN @OrderDir >= 0 THEN 'ASC'
    END DECLARE @SortExpression VARCHAR(300) = CONCAT(@OrderBy, ' ', @OrderDesc);


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
    AND (EXISTS (SELECT 1 FROM @ModelData) AND [M].[Id] IN (SELECT [ModelId] FROM @ModelData))
    AND 
    (
           (@YearFrom IS NULL       AND @YearTo IS NULL)
        OR (@YearFrom IS NOT NULL   AND @YearTo IS NULL     AND Year >= @YearFrom)
        OR (@YearFrom IS NULL       AND @YearTo IS NOT NULL AND Year <= @YearTo)
        OR (Year BETWEEN @YearFrom  AND @YearTo)
    )
    AND (@IsAvailable IS NULL OR IsAvailable = @IsAvailable)

ORDER BY
    CASE
        WHEN @SortExpression = 'ModelName ASC' THEN [M].[ModelName]
    END ASC,
    CASE
        WHEN @SortExpression = 'ModelName DESC' THEN [M].[ModelName]
    END DESC,
    CASE
        WHEN @SortExpression = 'BrandName ASC' THEN [B].[BrandName]
    END ASC,
    CASE
        WHEN @SortExpression = 'BrandName DESC' THEN [B].[BrandName]
    END DESC
 
 OFFSET (@Page -1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY