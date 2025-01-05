IF 
(EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @customerId AND IsActive = 0)) 
OR (NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @customerId AND IsActive = 1)) 
BEGIN RAISERROR ('Customer not found or is not active.',16, 1) END
ELSE

UPDATE dbo.Customers
SET 
	IsActive = 0, 
	ModifyDate = GETDATE()
WHERE 
	Id = @customerId 
AND IsActive = 1;

UPDATE dbo.Reservations
SET 
	ModifyDate = GETDATE(),
	StatusId = 2,
	IsActive = 0
WHERE 
	dbo.Reservation.CustomerId = @customerId
AND dbo.Reservation.IsActive = 1;

UPDATE dbo.Cars
SET
	IsAvailable = 1
WHERE
	Car.Id = (SELECT Car.Id FROM dbo.Rental WHERE CustomerId = @customerId AND IsActive = 1)

UPDATE dbo.Rental
SET
	ModifyDate = GETDATE(),
	IsActive = 0
WHERE 
	dbo.Rental.CustomerId = @customerId