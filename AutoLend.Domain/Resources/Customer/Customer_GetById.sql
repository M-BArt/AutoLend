IF 
(EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @customerId AND IsActive = 0)) 
OR (NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @customerId AND IsActive = 1)) 
BEGIN RAISERROR ('Customer not found or is not active.',16, 1) END
ELSE

SELECT  
	* 
FROM 
	dbo.Customers AS CU
WHERE 
	CU.id = @customerId
AND	CU.IsActive = 1;
