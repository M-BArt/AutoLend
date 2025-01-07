SELECT  
    [CU].[Id],
    [CU].[CreateDate],
    [CU].[ModifyDate],
    [CU].[FirstName],
    [CU].[LastName],
    [CU].[Email],
    [CU].[LicenseNumber],
    [CU].[Phone],
    [CU].[Address],
    [CU].[DateOfBirth],
    [CU].[HasActiveRental]
FROM 
	[dbo].[Customers] AS [CU]
WHERE 
	[CU].[Id] = @customerId
AND	[CU].[IsActive] = 1;
