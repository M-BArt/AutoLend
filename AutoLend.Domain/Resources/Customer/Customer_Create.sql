IF EXISTS (SELECT 1 FROM dbo.Customers WHERE Email = @Email AND dbo.Customers.IsActive = 1)
BEGIN RAISERROR ('Customer already exists in the database.',16, 1) END
ELSE

BEGIN
INSERT INTO dbo.Customers 
	(
	[Id],
	[CreateDate],
	[ModifyDate],
	[Firstname], 
	[Lastname], 
	[Email], 
	[Phone], 
	[Address],
	[LicenseNumber],
	[DateOfBirth],
	[isActive]) 
VALUES
	(
	NEWID(),
	GETDATE(),
	NULL,
	@Firstname, 
	@Lastname, 
	@Email, 
	@Phone, 
	@Address,
	@LicenseNumber,
	@DateOfBirth,
	1
	)
END

