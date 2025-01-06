UPDATE 
	[dbo].[Reservations]
SET 
	[ModifyDate] = GETDATE(),
	[IsActive] = 0
WHERE 
	[Id] = @reservationId 
AND [IsActive] = 1;
