IF 
	(EXISTS (SELECT 1 FROM dbo.Reservations WHERE Id = @reservationId AND IsActive = 0)) 
OR	(NOT EXISTS (SELECT 1 FROM dbo.Reservations WHERE Id = @reservationId)) 

BEGIN RAISERROR ('Reservation not found or is not active.',16, 1) END
ELSE

UPDATE 
	dbo.Reservations
SET 
	IsActive = 0,
	ModifyDate = GETDATE()
WHERE 
	Id = @reservationId 
AND IsActive = 1;
