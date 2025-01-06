UPDATE [RE]
SET
	[RE].[ModifyDate] = GETDATE(),
	[RE].[StatusId] = @statusId
FROM
	[dbo].[Rentals] AS [RE]
WHERE
	[RE].[Id] = @rentalId
AND [RE].[IsActive] = 1