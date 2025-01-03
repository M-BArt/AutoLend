SELECT DISTINCT * 
FROM dbo.Rental AS rental 
WHERE rental.id = @rentalId
AND isActive = 1;