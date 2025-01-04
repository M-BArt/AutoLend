IF 
(EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @customerId AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @customerId)) 
BEGIN RAISERROR ('Customer not found or is not active.',16, 1) END
ELSE

UPDATE dbo.Customers
SET isActive = 0 
WHERE id = @customerId 
AND isActive = 1;