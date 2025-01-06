UPDATE CU
	SET 
		[CU].[FirstName]		= COALESCE(NULLIF(@FirstName, ''), C.FirstName),
		[CU].[LastName]			= COALESCE(NULLIF(@LastName, ''), C.LastName),
		[CU].[LicenseNumber]	= COALESCE(NULLIF(@LicenseNumber, ''), C.LicenseNumber),
		[CU].[Phone]			= COALESCE(NULLIF(@Phone, ''), C.Phone),
		[CU].[Address]			= COALESCE(NULLIF(@Address, ''), C.Address),
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
	

