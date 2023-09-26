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
![FakeCandidateService-DependencyInjection](https://github.com/kutaymalik/VkpApi/assets/56682209/7b6eb15f-d4ed-44a5-b94f-c464fa5925b7)

### Extension
![ToDtoExtension](https://github.com/kutaymalik/VkpApi/assets/56682209/f2afb296-6638-4471-82a5-7993425fc3ac)

### SwaggerImplementation
![SwaggerImplementation](https://github.com/kutaymalik/VkpApi/assets/56682209/80644afe-8061-428b-ae4d-70ae9bfa1e71)


### Global Logging Middleware Output
![GlobalLoggingMiddleware](https://github.com/kutaymalik/VkpApi/assets/56682209/454bb93f-117f-470a-80f3-c4eccdc41576)


### Global Exception Middleware 
![GlobalExceptionMiddleware](https://github.com/kutaymalik/VkpApi/assets/56682209/90413010-8e1a-48aa-95b9-5dcddd967595)
ode






