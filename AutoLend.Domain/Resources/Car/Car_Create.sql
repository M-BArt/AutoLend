INSERT INTO [dbo].[Cars] (
    [CreateDate],
    [ModifyDate],
    [ModelId],
    [Year],
    [LicensePlate],
    [IsAvailable],
    [IsActive]
) 
VALUES (
    GETDATE(),
    NULL,
    @ModelId,
    @Year,
    @LicensePlate,
    @IsAvailable,
    1
)
SELECT Scope_Identity()