UPDATE CA
	SET 
		[CA].[year]			= COALESCE(NULLIF(@Year, 0), [CA].[year]), 
		[CA].[ModelId]		= COALESCE((SELECT [id] FROM [dbo].[Models] WHERE [Models].[ModelName] LIKE '%' + NULLIF(@ModelName, '') + '%'), [CA].[ModelId]),
		[CA].[LicensePlate]	= COALESCE(NULLIF(@LicensePlate, ''), [CA].[LicensePlate]),
		[CA].[IsAvailable]	= COALESCE(@IsAvailable, [CA].[IsAvailable]),
		[CA].[Cost]			= COALESCE(NULLIF(@Cost, 0), [CA].Cost),
		[CA].[ModifyDate]	= GETDATE()
	
	FROM [dbo].[Cars]				AS [CA] 
		INNER JOIN [dbo].[Models]	AS [M]	ON [CA].[ModelId] = [M].[id]
	
	WHERE 
			[CA].[Id] = @Id
		AND [CA].[IsActive] = 1;