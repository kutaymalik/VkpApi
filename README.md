# VkpApi Week2 HW


An API and the infrastructure of this API have been prepared for the Vakıfbank - Patika FullStack bootcamp. This project is a digital voting system. Candidates and users can be created. Votes can be cast with user information. The results can be brought in once the voting process is completed.


## Installation

After cloning the project, open the solution with Visual Studio. Run the project via IIS Express. Enter the required values ​​into the input section with Swagger.

## Usage

To add migration:
In VkpApi folder
```
Packager Manager Console > 
Add-Migration MigrationName -Project Vkp.Data
```

To update:
```
PowerShell >
dotnet ef database update --verbose --project Vkp.Data --startup-project Vkp.Api
```

To update database: 
```
update-database -Project Vkp.Data
```

Ex Register:
```
{
    "TCKN": "12345678901",
    "Password": "myPassword"
}
```

Ex: Candidate: 
```
{
  "name": "Candidate1",
  "party": "Party1"
}
```

## Dependencies
- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore
    
## Demo

### Fake Service - Dependency Injection
- This service creates fake candidates. It was written as an example instead of a user login service. <br/> <br/>
![FakeCandidateService-DependencyInjection](https://github.com/kutaymalik/VkpApi/assets/56682209/9b1ea6e4-298a-435c-97ca-0205a5ef6ce6)


### Extension
- This extension is used to convert from the main model to a dto model that contains only the necessary fields. <br/> <br/>
![ToDtoExtension](https://github.com/kutaymalik/VkpApi/assets/56682209/72e57624-6680-4249-abb5-cebf9f61e500)


### SwaggerImplementation <br/> <br/>
![SwaggerImplementation](https://github.com/kutaymalik/VkpApi/assets/56682209/8b07ad4a-335e-4bf2-8de6-f9b3ffd6a616)



### Global Logging Middleware Output
- This middleware logs http requests. <br/> <br/>
![GlobalLoggingMiddleware](https://github.com/kutaymalik/VkpApi/assets/56682209/912f8b5f-ed2f-4821-ba89-6f62a1b63e8f)


### Global Exception Middleware 
- This middleware API logs in case of exceptions (status 500 code). <br/> <br/>
![GlobalExceptionMiddleware](https://github.com/kutaymalik/VkpApi/assets/56682209/fc260e9d-3b3d-4449-a40f-6cf70a3fe44f)







