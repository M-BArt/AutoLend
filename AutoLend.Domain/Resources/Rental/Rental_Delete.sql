UPDATE dbo.Rentals
SET isActive = 0 
WHERE id = @rentalId AND isActive = 1;