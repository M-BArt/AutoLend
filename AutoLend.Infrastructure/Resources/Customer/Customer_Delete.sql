UPDATE dbo.Customer 
SET isActive = 0 
WHERE id = @customerId 
AND isActive = 1;