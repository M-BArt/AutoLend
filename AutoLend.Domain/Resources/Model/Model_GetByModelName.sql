SELECT
	[MO].[Id],
	[MO].[ModelName],
	[MO].[BrandId]
FROM 
	[dbo].[Models] AS [MO]
WHERE 
	[MO].[ModelName] = @ModelName
AND	[MO].[IsActive] = 1