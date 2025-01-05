DECLARE @ModelId INT;

SELECT 
    @ModelId = Id 
FROM 
    dbo.Models 
WHERE 
    ModelName LIKE '%' + @ModelName + '%';

IF @ModelId IS NULL
    BEGIN
        RAISERROR ('Model not found.', 16, 1);
    END
ELSE
    BEGIN
    INSERT INTO [dbo].[Cars] (
        [ModelId],
        [Year],
        [LicensePlate],
        [IsAvailable],
        [IsActive]
    ) 
    VALUES (
        @ModelId,
        @Year,
        @LicensePlate,
        @IsAvailable,
        1
    )
END