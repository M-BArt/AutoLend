IF 
(EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @Id AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @Id)) 
BEGIN RAISERROR ('Customer not found or is not active.',16, 1) END
ELSE

UPDATE Customers
	SET 
	Customers.FirstName = COALESCE(NULLIF(@FirstName, ''), Customers.FirstName),
	Customers.LastName = COALESCE(NULLIF(@LastName, ''), Customers.LastName),
	Customers.LicenseNumber = COALESCE(NULLIF(@LicenseNumber, ''), Customers.LicenseNumber),
	Customers.Phone = COALESCE(NULLIF(@Phone, ''), Customers.Phone),
	Customers.Address = COALESCE(NULLIF(@Address, ''), Customers.Address),
	Customers.ModifyDate = GETDATE()
	FROM dbo.Customers WHERE Customers.Id = @Id AND IsActive = 1;

IF @DateOfBirth IS NOT NULL
    BEGIN
        UPDATE dbo.Customers
        SET DateOfBirth = @DateOfBirth
        WHERE Id = @Id AND IsActive = 1;
    END
	

