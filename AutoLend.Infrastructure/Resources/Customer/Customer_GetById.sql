SELECT DISTINCT * 
FROM dbo.Customer AS customer 
WHERE customer.id = @customerId
AND isActive = 1;