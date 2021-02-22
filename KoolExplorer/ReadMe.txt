ASP.NET Core 3.1 with Razor Project Setup Reference from YouTube:
https://www.youtube.com/watch?v=C5cnZ-gZy2I&t=1021s


Things to install: Tools > Nuget > Manage Nuget
-----
newtonsoft.json v10
Razor.RuntimeCompilation v3
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.tools [to use the migration function]


Use Package Manager Console to Update db
Step 1: add-migration <migration_name>   //To create migration record
Step 2: update-database					 //Perform the migration
