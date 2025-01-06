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
