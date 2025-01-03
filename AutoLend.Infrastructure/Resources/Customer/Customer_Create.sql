IF EXISTS (SELECT 1 FROM dbo.Customer WHERE Email = @Email)
BEGIN RAISERROR ('Email already exists in the database.',16, 1) END
ELSE

BEGIN
INSERT INTO dbo.Customer 
	(
	[Id],
	[CreateDate],
	[ModifyDate],
	[Firstname], 
	[Lastname], 
	[Email], 
	[Phone], 
	[Address],
	[Gender],
	[DateOfBirth],
	[isActive]) 
VALUES
	(
	NEWID(),
	GETDATE(),
	GETDATE(),
	@Firstname, 
	@Lastname, 
	@Email, 
	@Phone, 
	@Address,
	@Gender,
	@DateOfBirth,
	1
	)
END