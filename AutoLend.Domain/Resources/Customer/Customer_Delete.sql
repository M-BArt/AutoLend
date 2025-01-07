UPDATE [CU]
SET 
	[CU].[IsActive] = 0, 
	[CU].[ModifyDate] = GETDATE()
FROM 
	[dbo].[Customers] AS [CU]
WHERE 
	[CU].[Id] = @customerId 
AND [CU].[IsActive] = 1;

UPDATE [R]
SET 
	[R].[ModifyDate] = GETDATE(),
	[R].[StatusId] = 2
FROM
	[dbo].[Reservations] AS [R]
WHERE 
	[R].[CustomerId] = @customerId
AND [R].[IsActive] = 1;

UPDATE [CA]
SET
	[CA].[ModifyDate] = GETDATE(),
	[CA].[IsAvailable] = 1
FROM
	[dbo].[Cars] AS [CA]
WHERE
	[CA].[Id] = (SELECT [CA].[Id] FROM [dbo].[Rentals] WHERE [CustomerId] = @customerId AND [IsActive] = 1 AND [StatusId] = 1)
AND [CA].[IsActive] = 1

UPDATE [RE]
SET
	[RE].[ModifyDate] = GETDATE(),
	[RE].[StatusId] = 2
FROM
	[dbo].[Rentals] AS [RE]
WHERE 
	[RE].[CustomerId] = @customerId
AND [RE].[StatusId] = 1 
AND [RE].[IsActive] = 1