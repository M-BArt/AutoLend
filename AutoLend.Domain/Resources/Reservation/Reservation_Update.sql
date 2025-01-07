UPDATE [R]
SET 
	[R].[ReservationFrom] = @ReservationFrom,
	[R].[ReservationTo] = @ReservationTo,
	[R].[Description] = @Description
FROM [dbo].[Reservations] AS [R]
WHERE 
		[R].[Id] = @Id
	AND [R].[IsActive] = 1;