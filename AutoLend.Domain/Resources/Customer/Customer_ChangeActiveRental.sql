UPDATE [CU]
SET
	[CU].[HasActiveRental] = 0
FROM 
	[dbo].[Customers] AS [CU]
WHERE
	[CU].[Id] = @customerId
AND [CU].[IsActive] = 1