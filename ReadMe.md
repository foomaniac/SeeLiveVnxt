# Introduction 

SeeLive Events listing web application

# Getting Started

The solution contains 4 main projects:

1) SeeLive.Api
1) SeeLive.Domain
1) SeeLive.Infrastructure
1) SeeLive.Identity.Api

#### EF Migrations

The application is EntityFramework Migrations enabled and the project that contains the migrations is SeeLive.Infrastructure.

To run the EF Migration commands you need to utilise the --startup-project arguement. 

Example using the VS 2019 Package Manager Console:

1) Select src\SeeLive.Infrastructure in the 'Default project' window
1) cd to src\SeeLive.Infrastructure
1) Run the example command below to initial the database:

```
dotnet ef database update --startup-project ../SeeLive.Api
```

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

