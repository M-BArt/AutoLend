IF 
(EXISTS (SELECT 1 FROM dbo.Reservations WHERE Id = @Id AND IsActive = 0)) 
OR (NOT EXISTS (SELECT 1 FROM dbo.Reservations WHERE Id = @Id AND IsAcative = 1)) 
BEGIN RAISERROR ('Reservation not found or is not active.',16, 1) END
ELSE

UPDATE R
	SET 
		R.ReservationFrom = @ReservationFrom,
		R.ReservationTo = @ReservationTo,
		R.Descriptions = @Descriptions
	FROM dbo.Reservations AS R
	WHERE 
			R.Id = @Id
		AND R.IsActive = 1;