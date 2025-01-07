SELECT
	[CA].[Id],
	[CA].[LicensePlate],
	[CA].[IsAvailable],
	[CA].[Cost]
FROM
	[dbo].[Cars] AS [CA]
WHERE
	[CA].[LicensePlate] = @LicensePlate
AND	[CA].[IsActive] = 1