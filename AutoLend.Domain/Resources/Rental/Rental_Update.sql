UPDATE RE
	SET 
		[RE].[StatusId]		= COALESCE(	NULLIF(@StatusId, ''),		[RE].[StatusId]),
		[RE].[RentalDate]	= COALESCE(	NULLIF(@RentalDate, ''),	[RE].[RentalDate]),
		[RE].[ReturnDate]	= COALESCE(	NULLIF(@ReturnDate, ''),	[RE].[ReturnDate]),
		[RE].[Cost]			= COALESCE(	NULLIF(@Cost, ''),			[RE].[Cost])
	FROM 
		[dbo].[Rentals] AS [RE]
	WHERE 
		[RE].[Id] = @Id
	AND [RE].[IsActive] = 1;

