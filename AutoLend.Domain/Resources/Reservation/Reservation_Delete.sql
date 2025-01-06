UPDATE 
	[dbo].[Reservations]
SET 
	[IsActive] = 0,
	[ModifyDate] = GETDATE()
WHERE 
	[Id] = @reservationId 
AND [IsActive] = 1;
