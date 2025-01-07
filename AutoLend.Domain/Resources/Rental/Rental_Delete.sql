UPDATE [RE]

SET 
	[IsActive] = 0 
FROM
	[dbo].[Rentals] AS [RE]
WHERE 
	[RE].[Id] = @rentalId 
AND [IsActive] = 1
AND [StatusId] != 1;


UPDATE [CU]
SET 
	[CU].[HasActiveRental] = 0
FROM 
	[dbo].[Customers] AS [CU]
WHERE 
	[CU].[Id] = (SELECT [RE].[CustomerId] FROM [dbo.Rentals] AS [RE] WHERE [RE].Id = @rentalId)
AND [CU].[IsActive] = 1

