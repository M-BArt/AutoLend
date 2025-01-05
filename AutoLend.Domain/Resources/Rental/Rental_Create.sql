DECLARE @CustomerId CHAR(36) = (
	SELECT 
		dbo.Customers.Id 
	FROM 
		dbo.Customers 
	WHERE 
			LicenseNumber = @LicenseNumber
		AND IsActive = 1
	)

DECLARE @CarId INT = (
	SELECT 
		dbo.Cars .Id 
	FROM 
		dbo.Cars 
	WHERE 
		LicensePlate = @LicensePlate
	AND IsActive = 1
	)

DECLARE @StatusId INT = (
	SELECT 
		Id 
	FROM 
		dbo.Status 
	WHERE 
			StatusName = 'Confirmed'
 		AND IsActive = 1
	)

BEGIN
INSERT INTO dbo.Rental
	(
	[CreateDate],
    [ModifyDate],
    [CarId],
    [CustomerId],
    [RentalDate],
    [ReturnDate],
    [StatusId],
    [TotalCost],
    [IsActive]
	) 
VALUES
	(
	GETDATE(),
	NULL,
	@CarId,
	@CustomerId,
	@RentalDate,
	@ReturnDate,
	@StatusId,
	@TotalCost,
	1
	)
END

