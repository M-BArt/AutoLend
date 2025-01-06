UPDATE [CA]
SET 
	[CA].[IsActive] = 0 
FROM 
	[dbo].[Cars] AS [CA]
WHERE 
	[CA].[Id] = @carId 
AND [IsActive] = 1;