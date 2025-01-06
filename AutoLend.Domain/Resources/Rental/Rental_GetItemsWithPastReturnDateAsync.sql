SELECT *
FROM
	[dbo].[Rentals] AS [RE]
WHERE
	[RE].[ReturnDate] < GETDATE()
AND	[RE].[StatusId] = 1
AND	[RE].[IsActive] = 1