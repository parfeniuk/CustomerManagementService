# CustomerManagementService - configuration notices

# SQL Server Credentials
CustomerManagementService uses SQL Server and requires installed SQL Server on local machine as well as changes in Connection String credentials.
Replace User Id and Password placeholders in the "ConnectionStrings" section of appsettings.Development.json config file on your actual SQL Server Credentials.

# Database Migration
CustomerManagementService uses DbUp for Database schema migration.
Database Migration implemented in CustomerManagementService.Infrastructure.DbMigration Project and run all required SQL scripts automatically on application start from Visual Studio.
You only need to check that both projects - CustomerManagementService.Infrastructure.DbMigration and CustomerManagementService.WebAPI set as startup projects
In Visual Studio go to Solution Properties -> Multiple startup projects: set Start Action for CustomerManagementService.Infrastructure.DbMigration project as well as for CustomerManagementService.WebAPI project.
