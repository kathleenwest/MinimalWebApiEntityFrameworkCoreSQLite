using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaStore.Model;

namespace PizzaStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // SQLite Database Provider Setup

            // Connection string
            string? connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";

            // Add database context using SQLite
            builder.Services.AddSqlite<PizzaDb>(connectionString);

            // In-Memory Database Provider
            //builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));

            // Swagger/OpenAPI
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PizzaStore API",
                    Description = "Making the Pizzas you love",
                    Version = "v1"
                });
            });

            // Build the the web application
            WebApplication? app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Use swagger if in development
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // WebApi Endpoints

            // Get Default
            app.MapGet("/", () => "Hello World! This is a minimal Pizza Store web api with in-memory database.");

            // Get all pizzas
            app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());

            app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) => 
            { 
                await db.Pizzas.AddAsync(pizza);
                await db.SaveChangesAsync();
                return Results.Created($"/pizza/{pizza.Id}", pizza);
            });

            // Get a single pizza
            app.MapGet("/pizza/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));

            // Update a pizza
            app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
            {
                Pizza? pizza = await db.Pizzas.FindAsync(id);
                if (pizza is null) return Results.NotFound();
                pizza.Name = updatepizza.Name;
                pizza.Description = updatepizza.Description;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            // Delete a pizza
            app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) =>
            {
                Pizza? pizza = await db.Pizzas.FindAsync(id);
                if (pizza is null)
                {
                    return Results.NotFound();
                }
                db.Pizzas.Remove(pizza);
                await db.SaveChangesAsync();
                return Results.Ok();
            });

            // Run the web application
            app.Run();
        }
    }
}
