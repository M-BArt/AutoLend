SELECT CASE
	WHEN EXISTS(
	SELECT 1 
	FROM 
	[dbo].[Cars] AS [CA] 
	WHERE 
		[CA].[IsActive] = 1
	AND	[CA].[LicensePlate] = @LicensePlate
	AND (@excludeCarId IS NULL OR [CA].[Id] != @excludeCarId)
	)
	THEN 1
	ELSE 0
END
