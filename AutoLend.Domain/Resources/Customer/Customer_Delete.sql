UPDATE [dbo].[Customers]
SET 
	[IsActive] = 0, 
	[ModifyDate] = GETDATE()
WHERE 
	[Id] = @customerId 
AND [IsActive] = 1;

UPDATE [dbo].[Reservations]
SET 
	[ModifyDate] = GETDATE(),
	[StatusId] = 2,
	[IsActive] = 0
WHERE 
	[dbo].[Reservation].[CustomerId] = @customerId
AND [dbo].[Reservation].[IsActive] = 1;

UPDATE [dbo].[Cars]
SET
	[ModifyDate] = GETDATE(),
	[IsAvailable] = 1
WHERE
	[Car].[Id] = (SELECT [Car].[Id] FROM [dbo].[Rentals] WHERE [CustomerId] = @customerId AND [IsActive] = 1)

UPDATE [dbo].[Rentals]
SET
	[ModifyDate] = GETDATE(),
	[IsActive] = 0
WHERE 
	[dbo].[Rentals].[CustomerId] = @customerId
AND ([StatusId] = 3 
	OR [StatusId] = 2)