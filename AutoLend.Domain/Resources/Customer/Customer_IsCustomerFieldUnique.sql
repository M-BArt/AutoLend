IF @Field = 'Email'
    BEGIN
        SELECT CASE
            WHEN EXISTS (
                SELECT 1
                FROM [dbo].[Customers]
                WHERE [Email] = @Value
                AND (@ExcludeCustomerId IS NULL OR Id != @ExcludeCustomerId)
            )
            THEN 1
            ELSE 0
        END;
    END
IF @Field = 'LicenseNumber'
    BEGIN
        SELECT CASE
            WHEN EXISTS (
                SELECT 1
                FROM [dbo].[Customers]
                WHERE [LicenseNumber] = @Value
                AND (@ExcludeCustomerId IS NULL OR Id != @ExcludeCustomerId)
            )
            THEN 1
            ELSE 0
        END;
    END
