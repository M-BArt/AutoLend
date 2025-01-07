INSERT INTO [dbo].[Cars] (
    [CreateDate],
    [ModifyDate],
    [ModelId],
    [Year],
    [LicensePlate],
    [IsAvailable],
    [IsActive],
    [Cost]
) 
VALUES (
    GETDATE(),
    NULL,
    @ModelId,
    @Year,
    @LicensePlate,
    @IsAvailable,
    1,
    @Cost
)
SELECT Scope_Identity()