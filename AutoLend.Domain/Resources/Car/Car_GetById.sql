﻿SELECT 
	[CA].[Id], 
	[B].[BrandName], 
	[M].[ModelName], 
	[CA].[Year], 
	[CA].[LicensePlate], 
	[CA].[IsAvailable],
	[CA].[Cost]

FROM [dbo].[Cars]				AS [CA] 
	INNER JOIN [dbo].[Models]	AS [M]  ON [CA].[ModelId] = [M].[Id]
	INNER JOIN [dbo].[Brands]	AS [B]  ON [M].[BrandId] = [B].[Id]

WHERE 
		[CA].[Id] = @carId 
	AND [CA].[IsActive] = 1
	AND [M].[IsActive] = 1;
