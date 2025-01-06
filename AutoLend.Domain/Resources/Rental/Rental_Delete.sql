UPDATE 
	[dbo].[Rentals]
SET 
	[IsActive] = 0 
WHERE 
	[Id] = @rentalId 
AND [IsActive] = 1
AND [StatusId] != 1;


UPDATE [CU]
SET 
	[CU].[HasActiveRental] = 0
FROM 
	[dbo].[Customers] AS [CU]
WHERE 
	[CU].[Id] = @customerId
AND [CU].[IsActive] = 1
