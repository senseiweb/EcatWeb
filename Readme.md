# eCAT Web Services
### About
The EPME Course Application Toolkit Webservices provides backend support for companion client web applications. 

### Requirments
The following is a list of requirements for development of the eCAT Webservices project.

##### Development Environment
* .Net 4.6
*  Asp.Net Core 1
*  Visual Studio 2017 (current at RC1)
*  SQL Server 

##### Dependencis
eCAT Webservices development dependencies are managed by [Nuget](https://www.nuget.org/), access to the nuget and microsoft sites are needed in order to download the following list of major packages:
* Entity Framework v6.1.3 (ORM for SQL Server)
* Breeze Server [(Client/Server Data Managment)](http://breeze.github.io/doc-net/)
* OpenAuthenication [()]()

##### Database Configuration
eCAT Webservices uses [Entity Framework's code-first]() methodology, implementing the bounded context design pattern. This design pattern allows us to build database objects around the "seams" of our 
application, i.e. all functionality related to particular feature are placed within its own context and by extension database schema. 

Configurations for each of the contexts lives in the DataLib project under the configuration folder. Each configuration is decorated with a 'Config{Context}Context' attributes as marker for auto discovery during migrations and 
creation operations.

Current Bounded Contexts
* GlobalContext: DbContext for use across all app functions...for entities not tied to any particular app feature.
    * Commands
        1. `Enable-Migrations -ContextTypeName Ecat.DataLib.Context.GlobalCtx -ProjectName Ecat.DataLib -MigrationsDirectory MGblCtx -StartUpProjectName Ecat.DataLib`
        2. `Add-Migration -ConfigurationTypeName Ecat.DataLib.MGblCtx.Configuration -Name *{Descriptive Name for Changes}* -ProjectName Ecat.DataLib -StartUpProjectName Ecat.DataLib`
        3. `Update-Database -ConfigurationTypeName Ecat.DataLib.MGblCtx.Configuration -ProjectName Ecat.DataLib -StartUpProjectName Ecat.DataLib`
* SchoolCtx: Handles all db operations affecting school specific operations. 
	* Commands
		 1. `Enable-Migrations -ContextTypeName Ecat.DataLib.Context.SchoolCtx -ProjectName Ecat.DataLib -MigrationsDirectory MSchCtx -StartUpProjectName Ecat.DataLib`
         2. `Add-Migration -ConfigurationTypeName Ecat.DataLib.MSchCtx.Configuration -Name *{Descriptive Name for Changes}* -ProjectName Ecat.DataLib -StartUpProjectName Ecat.DataLib`
         3. `Update-Database -ConfigurationTypeName Ecat.DataLib.MSchCtx.Configuration -ProjectName Ecat.DataLib -StartUpProjectName Ecat.DataLib`
