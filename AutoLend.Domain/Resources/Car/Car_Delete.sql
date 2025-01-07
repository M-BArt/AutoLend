UPDATE [CA]
SET 
	[CA].[IsActive] = 0 
FROM 
	[dbo].[Cars] AS [CA]
WHERE 
	[CA].[Id] = @carId 
AND [IsActive] = 1;

UPDATE [R]
SET
	[R].[StatusId] = 2
FROM
	[dbo].[Rentals] AS [R]
WHERE
	[R].[Id] = @carId
AND [R].[IsActive] = 1