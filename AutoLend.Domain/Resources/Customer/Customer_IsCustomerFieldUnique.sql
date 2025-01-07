IF @field= 'Email'
BEGIN
    SELECT CASE
        WHEN EXISTS (
            SELECT 1
            FROM [dbo].[Customers]
            WHERE [Email] = @value
            AND (@excludeCustomerId IS NULL OR Id != @ExcludeCustomerId)
        )
        THEN 1
        ELSE 0
    END
END

IF @field = 'LicenseNumber'
BEGIN
    SELECT CASE
        WHEN EXISTS (
            SELECT 1
            FROM [dbo].[Customers]
            WHERE [LicenseNumber] = @value
            AND (@excludeCustomerId IS NULL OR Id != @ExcludeCustomerId)
        )
        THEN 1
        ELSE 0
    END
END
