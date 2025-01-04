UPDATE dbo.Rental
SET isActive = 0 
WHERE id = @rentalId AND isActive = 1;