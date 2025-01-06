﻿INSERT INTO dbo.Customers 
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
SELECT Scope_Identity()