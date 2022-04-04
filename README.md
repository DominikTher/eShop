# README

This readme provides just some basic information. Be aware of having installed sql, dotnet tools, etc. You can also use database in memory.

If you find this insufficient let me know. I'm open to having a discussion. And if you find this solution absolutely out of scope, that's fine, just let me know feedback if possible. I must admit that this is not a production-grade app as you wish in the case study. For that reason, I added some points at the end of this readme.

# How to set up the application
1. Create database using dotnet tools. 
    - check connection string in appsettings.json
    - navigate to the folder eShop.Persistence and run following command
    - dotnet ef database update -p .\eShop.Persistence.csproj -s ..\..\Api\eShop.Api\eShop.Api.csproj

2. Run app from command line
    - navigate to the folder eShop.Api and run following command
    - dotnet run

You can use your own steps. For example if you like visual studo interface more.

# How to run the tests
1. Navigate to the folder eShop and run following command
2. dotnet test

There are more possiblities.

# Spec
- [x] swagger /swagger/index.htm
- [x] unit test project
- [x] .net 6 lts
- [x] simple example of validation and error handling
- [x] sql database, ef core, seed
- [x] list + paging (default is five now, easy to change to ten)
- [x] one product
- [x] update description
- [x] versioning

# Possible things to discuss (because I didn't implemented everything)
- [ ] Unit testing, mock data will be static, no database
- [ ] Integration test, either real database or in memory database, or any other provider, you can modify startup for integrations tests if necessary
- [ ] Authentication and authorization
- [ ] Health checks, for database, app, ... Measuring availibility, notifications, /health endpoint with aggregated statuses
- [ ] Caching layer, request ask database every time right now
- [ ] More description for swagger, statuses, response messages
- [ ] Logging, serilog, sql, txt, azure ...
- [ ] Secrets and configuration, for simplicity connection string is in public config
- [ ] commit and branch history that reflect real world
