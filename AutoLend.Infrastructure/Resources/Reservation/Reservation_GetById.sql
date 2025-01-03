SELECT DISTINCT * 
FROM dbo.Reservation AS reservation 
WHERE 
reservation.id = @reservationId 
AND isActive = 1;