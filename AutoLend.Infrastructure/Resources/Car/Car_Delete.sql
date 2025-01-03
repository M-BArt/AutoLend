UPDATE dbo.Car 
SET isActive = 0 
WHERE id = @carId AND isActive = 1;