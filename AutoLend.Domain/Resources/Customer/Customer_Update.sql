UPDATE [CU]
	SET 
		[CU].[FirstName]		= COALESCE(NULLIF(@FirstName, ''), [CU].[FirstName]),
		[CU].[LastName]			= COALESCE(NULLIF(@LastName, ''), [CU].[LastName]),
		[CU].[LicenseNumber]	= COALESCE(NULLIF(@LicenseNumber, ''), [CU].[LicenseNumber]),
		[CU].[Phone]			= COALESCE(NULLIF(@Phone, ''), [CU].[Phone]),
		[CU].[Address]			= COALESCE(NULLIF(@Address, ''), [CU].[Address]),
		[CU].[ModifyDate]		= GETDATE()
	FROM 
		[dbo].[Customers] AS [CU]
	WHERE 
		[CU].[Id] = @Id
	AND [IsActive] = 1;

IF @DateOfBirth IS NOT NULL
    BEGIN
        UPDATE [dbo].[Customers]
        SET 
			[DateOfBirth] = @DateOfBirth
        WHERE 
			[Id] = @Id
		AND [IsActive] = 1;
    END
	

