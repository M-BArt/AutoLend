UPDATE dbo.Reservation
SET isActive = 0 
WHERE id = @reservationId AND isActive = 1;