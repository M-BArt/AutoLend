SELECT 
	CU.Id, 
	CU.CreateDate, 
	CU.ModifyDate, 
	CU.FirstName, 
	CU.LastName, 
	CU.Email, 
	CU.LicenseNumber, 
	CU.Phone, 
	CU.DateofBirth, 
	CU.HasActiveRental,
	CU.Address 
FROM 
	dbo.Customers AS CU
WHERE
	CU.IsActive = 1;