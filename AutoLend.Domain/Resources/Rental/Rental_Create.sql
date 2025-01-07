DECLARE @CustomerId CHAR(36) = (
	SELECT 
		[dbo].[Customers].[Id] 
	FROM 
		[dbo].[Customers] 
	WHERE 
			[LicenseNumber] = @LicenseNumber
		AND [IsActive] = 1
	)

DECLARE @CarId INT = (
	SELECT 
		[dbo].[Cars].[Id]
	FROM 
		[dbo].[Cars]
	WHERE 
		[LicensePlate] = @LicensePlate
	AND [IsActive] = 1
	)

DECLARE @StatusId INT = (
	SELECT 
		[Id] 
	FROM 
		[dbo].[Status] 
	WHERE 
			[StatusName] = 'Confirmed'
 		AND [IsActive] = 1
	)


INSERT INTO dbo.Rentals
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

SELECT Scope_Identity()

UPDATE [CU]
SET
	[CU].[HasActiveRental] = 1
FROM
	[dbo].[Customers] AS [CU]
WHERE
	[CU].[Id] = @CustomerId
AND [CU].[IsActive] = 1

UPDATE [CA]
SET
	[CA].[IsAvailable] = 0
FROM
	[dbo].[Cars] AS [CA]
WHERE
	[CA].[Id] = @CarId
AND [CA].[IsActive] = 1