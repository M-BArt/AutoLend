SELECT dbo.Reservations.Id, dbo.Reservations.CreateDate, dbo.Reservations.ModifyDate, 
ReservationFrom, ReservationTo, dbo.Reservations.Description, 
StatusName, BrandName, ModelName, LicensePlate, FirstName, LastName, Email 
FROM dbo.Reservations 
INNER JOIN dbo.ReservationStatus ON dbo.Reservations.StatusId = dbo.ReservationStatus.Id
INNER JOIN dbo.Cars ON dbo.Reservations.CarId = dbo.Cars.Id
INNER JOIN dbo.Customers ON dbo.Reservations.CustomerId = dbo.Customers.Id
INNER JOIN dbo.Models ON dbo.Cars.ModelId = dbo.Models.Id
INNER JOIN dbo.Brands ON dbo.Models.BrandId = dbo.Brands.Id
WHERE dbo.Reservations.IsActive = 1;