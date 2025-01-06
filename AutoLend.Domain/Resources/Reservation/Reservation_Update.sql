UPDATE [R]
SET 
	[R].[ReservationFrom] = @ReservationFrom,
	[R].[ReservationTo] = @ReservationTo,
	[R].[Descriptions] = @Descriptions
FROM [dbo].[Reservations] AS [R]
WHERE 
		[R].[Id] = @Id
	AND [R].[IsActive] = 1;