IF 
(EXISTS (SELECT 1 FROM dbo.Rental WHERE Id = @rentalId AND IsActive = 0)) 
OR (NOT EXISTS (SELECT 1 FROM dbo.Rental WHERE Id = @rentalId AND IsActive = 1)) 
BEGIN RAISERROR ('Rental not found or is not active.',16, 1) END
ELSE

SELECT
	RE.Id,
	RE.CreateDate,
	RE.ModifyDate,
	CA.LicensePlate,
	M.ModelName,
	B.BrandName,
	CU.FirstName,
	CU.LastName,
	CU.LicenseNumber,
	RE.RentalDate,
	RE.ReturnDate,
	S.StatusName,
	RE.TotalCost

FROM dbo.Rentals				AS RE
	INNER JOIN dbo.Cars			AS CA	ON RE.CarId = CA.Id
	INNER JOIN dbo.Customers	AS CU	ON RE.CustomerId = CU.Id
	INNER JOIN dbo.Models		AS M	ON CA.ModelId = M.Id
	INNER JOIN dbo.Brands		AS B	ON M.BrandId = B.Id
	INNER JOIN dbo.Status		AS S	ON RE.StatusId = S.Id

WHERE
		RE.IsActive = 1
	AND CA.IsActive = 1
	AND CU.IsActive = 1
	AND M.IsActive = 1
	AND B.IsActive = 1
	AND S.IsActive = 1
	
	AND RE.Id = @rentalId