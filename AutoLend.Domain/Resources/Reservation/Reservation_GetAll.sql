-- File: Reservation_GetAll.sql

SELECT 
	[R].[Id], 
	[R].[CreateDate], 
	[R].[ModifyDate], 
	[R].[ReservationFrom], 
	[R].[ReservationTo], 
	[R].[Description], 
	[S].[StatusName],
	[B].[BrandName], 
	[M].[ModelName], 
	[CA].[LicensePlate], 
	[CU].[FirstName], 
	[CU].[LastName], 
	[CU].[Email] 

FROM [dbo].[Reservations]		AS [R]	
INNER JOIN [dbo].[Status]		AS [S]	ON [R].StatusId = [S].[Id]
INNER JOIN [dbo].[Cars]			AS [CA]	ON [R].CarId = [CA].[Id]
INNER JOIN [dbo].[Customers]	AS [CU]	ON [R].CustomerId = [CU].[Id]
INNER JOIN [dbo].[Models]		AS [M]	ON [CA].ModelId = [M].[Id]
INNER JOIN [dbo].[Brands]		AS [B]	ON [M].BrandId = [B].[Id]

WHERE 
	[R].[IsActive] = 1
AND [CA].[IsActive] = 1
AND [M].[IsActive] = 1
AND [B].[IsActive] = 1
AND [S].[IsActive] = 1
AND [CU].[IsActive] = 1;