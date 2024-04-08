IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CustomerManagementService')
BEGIN
	CREATE DATABASE CustomerManagementService;
END