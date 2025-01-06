SELECT 
	[CU].[Id],
	[CU].[LicenseNumber],
	[CU].[FirstName],
	[CU].[LastName],
	[CU].[Email],
	[CU].[HasActiveRental]
FROM 
	[dbo].[Customers] AS [CU]
WHERE
	[LicenseNumber] = @licenseNumber
AND [IsActive] = 1