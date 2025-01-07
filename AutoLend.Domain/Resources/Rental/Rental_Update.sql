UPDATE RE
	SET 
		[RE].[StatusId]		= COALESCE(	NULLIF(@StatusId, ''),		[RE].[StatusId]),
		[RE].[RentalDate]	= COALESCE(	NULLIF(@RentalDate, ''),	[RE].[RentalDate]),
		[RE].[ReturnDate]	= COALESCE(	NULLIF(@ReturnDate, ''),	[RE].[ReturnDate]),
		[RE].[TotalCost]	= @TotalCost
	FROM 
		[dbo].[Rentals] AS [RE]
	WHERE 
		[RE].[Id] = @RentalId
	AND [RE].[IsActive] = 1;

