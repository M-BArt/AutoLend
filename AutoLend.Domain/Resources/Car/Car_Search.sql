SET @Page       = ISNULL(@Page, 1)
SET @PageSize   = ISNULL(@PageSize, 10)
SET @OrderBy    = ISNULL(@OrderBy, 'ModelName') 

DECLARE @OrderDesc VARCHAR(10) = 
    CASE
        WHEN @OrderDir IS NULL THEN 'ASC'
        WHEN @OrderDir <= 0 THEN 'DESC'
        ELSE 'ASC'
    END;

DECLARE @ModelData TABLE (
    ModelId INT
);

INSERT INTO @ModelData (ModelId)
SELECT ModelId
FROM OPENJSON(@ModelIdsJSON)
WITH (
    ModelId INT '$.ModelId'
);

SELECT 
    [M].[ModelName], 
    [B].[BrandName], 
    [CA].[Year], 
    [CA].[LicensePlate], 
    [CA].[IsAvailable] 
FROM [dbo].[Cars]               AS [CA]
    INNER JOIN [dbo].[Models]   AS [M] ON [CA].[ModelId] = [M].[Id]
    INNER JOIN [dbo].[Brands]   AS [B] ON [M].[BrandId] = [B].[Id]
WHERE 
        [CA].[IsActive] = 1 
    AND [M].[IsActive] = 1
    AND [B].[IsActive] = 1
    AND (@text IS NULL OR (M.ModelName LIKE '%' + @text + '%'))
    AND 
    (
           (@YearFrom   IS NULL       AND @YearTo IS NULL)
        OR (@YearFrom   IS NOT NULL   AND @YearTo IS NULL     AND [CA].[Year] >= @YearFrom)
        OR (@YearFrom   IS NULL       AND @YearTo IS NOT NULL AND [CA].[Year] <= @YearTo)
        OR ([CA].[Year] BETWEEN @YearFrom  AND @YearTo)
    )
    AND (@IsAvailable IS NULL OR [CA].[IsAvailable] = @IsAvailable)

ORDER BY
    CASE WHEN @OrderBy = 'ModelName ASC'    AND @OrderDesc = 'ASC'      THEN [M].[ModelName]    END ASC,
    CASE WHEN @OrderBy = 'ModelName DESC'   AND @OrderDesc = 'DESC'     THEN [M].[ModelName]    END DESC,
    CASE WHEN @OrderBy = 'BrandName ASC'    AND @OrderDesc = 'ASC'      THEN [B].[BrandName]    END ASC,
    CASE WHEN @OrderBy = 'BrandName DESC'   AND @OrderDesc = 'DESC'     THEN [B].[BrandName]    END DESC,
    CASE WHEN @OrderBy = 'Year'             AND @OrderDesc = 'ASC'      THEN [CA].[Year]        END ASC,
    CASE WHEN @OrderBy = 'Year'             AND @OrderDesc = 'DESC'     THEN [CA].[Year]        END DESC
OFFSET (@Page -1) * @PageSize ROWS FETCH NEXT @PageSize ROWS ONLY
