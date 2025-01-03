SELECT DISTINCT * 
FROM dbo.Car AS car 
WHERE car.id = @carId
AND isActive = 1;