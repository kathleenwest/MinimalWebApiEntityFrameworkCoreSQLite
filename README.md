# Pizza Store - Minimal Web Api - Entity Framework Core with SQLite

A minimal ASP.NET Core web api project to showcase Entity Framework Core with both SQLite and in-memory database implementations. This basic web api features CRUD operations with Http Verb Operations (Get, Post, Put, and Delete). Swagger documentation is configured for test and verification of the web api. See quick steps and demo code to quickly create and setup Entity Framework Core database implementations. This project code is the result of a Microsoft Learn tutorial "Use a database with minimal API, Entity Framework Core, and ASP.NET Core".

## Entity Framework Core with In-Memory Database Implementation

### Setup and Configuration
Install the ```Microsoft.EntityFrameworkCore.InMemory``` package.

Add the database context to the webapplication builder services with options to use the in-memory database

``` builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items")); ```

![in memory setup](/images/in-memory-setup.jpg)

### Demo Video

[![Watch the tutorial and demo video](/images/InMemoryImplementationTitle.jpg)](https://www.youtube.com/watch?v=RvzGf3Ci4us "Entity Framework Core In-Memory Database Implementation")

This tutorial and demo project will show how to set up, configure, and test a simple minimal web api with Microsoft Entity Framework Core in-memory database implementation.

In this video, you will learn how to use the Microsoft Entity Framework Core In-Memory package to create a web API that works with an in-memory database. This can be useful for testing or prototyping purposes, as the in-memory database does not persist any data after the app is stopped. You will see how to:

- Install the Microsoft Entity Framework Core In-Memory package for your project.
- Configure the web application builder services to add a database context with options to use the in-memory database.
- Run the web API and perform CRUD operations on the in-memory database using Swagger.
- Verify that the data in the in-memory database is lost when the app is restarted.

By the end of this video, you will have a better understanding of how to use the in-memory database provider with Entity Framework Core and how it differs from other database providers. You will also learn some of the benefits and limitations of using the in-memory database for your web API development.

If you enjoyed this video, please like, share, and subscribe to our channel. Also, don't forget to check out our other videos on Entity Framework Core and web API development. Thank you for watching and have a great day! 😊

## Entity Framwork Core with SQLite Database Implementation

![sqlite setup](/images/sqlite-setup.jpg)

### Install Packages

```Microsoft.EntityFrameworkCore.Sqlite```

```Microsoft.EntityFrameworkCore.Design```

### Add Setup Code to Program.cs

```
// SQLite Database Provider Setup

// Connection string
string? connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";

// Add database context using SQLite
builder.Services.AddSqlite<PizzaDb>(connectionString);
```
### Install Tools for EF Core

Tools for EF Core perform design-time development tasks. For example, they create migrations, apply migrations, and generate code for a model based on an existing database.

```dotnet tool install --global dotnet-ef```

### Rebuild Solution

Recommend completing a rebuild to resolve potential errors encountered with the next steps

### Generate Migration Files (for database)

```dotnet ef migrations add InitialCreate```

### Apply Migrations (Create Database and Schema)

```dotnet ef database update```

You should see a newly created Pizzas.db file in your project directory. 

If you are having issues, first try a rebuild and then re-run the above commands. I recommend watching the demo video for this section or completing the Microsoft Learn course: [Use a database with minimal API, Entity Framework Core, and ASP.NET Core](https://learn.microsoft.com/en-us/training/modules/build-web-api-minimal-database/)

### Demo Video

Coming Soon

## References

This project is the result of a Microsoft Learn tutorial project: [Use a database with minimal API, Entity Framework Core, and ASP.NET Core](https://learn.microsoft.com/en-us/training/modules/build-web-api-minimal-database/). However, I utilized some of the tutorial code into my own repo and made some modifications and improvements. I created this README to easily explain and demo the setup of the project.
