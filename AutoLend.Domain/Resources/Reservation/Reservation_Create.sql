DECLARE @CustomerId CHAR(36) = (
	SELECT 
		dbo.Customers.Id 
	FROM 
		dbo.Customers 
	WHERE 
			FirstName = @FirstName 
		AND LastName = @LastName 
		AND Email = @Email
		AND IsActive = 1
	)

DECLARE @CarId INT = (
	SELECT 
		Id 
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

IF @CustomerId IS NULL 
	BEGIN RAISERROR ('Customer not found or is not active.',16, 1) END
If @CarId IS NULL 
	BEGIN RAISERROR ('Car not found or is not active.',16, 1) END

INSERT INTO dbo.Reservations ( 
	[CreateDate],
	[ModifyDate],
	[ReservationFrom], 
	[ReservationTo], 
	[Description], 
	[StatusId],
	[CarId],
	[CustomerId],
	[IsActive])
VALUES (
	GETDATE(),
	NULL,
	@ReservationFrom,
	@ReservationTo,
	@Description,
	@StatusId,
	@CarId,
	@CustomerId,
	1
)

