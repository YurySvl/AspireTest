using Microsoft.EntityFrameworkCore;
using UserApp.Database;
using UserApp.Database.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & health checks
builder.AddServiceDefaults();

// Add DbContext, "userdb" is the connection string name
builder.AddSqlServerDbContext<UserDbContext>("userdb", configureDbContextOptions: options =>
{
    // This configures the inner EF Core options
    options.UseSqlServer(sqlOptions =>
    {
        // TELL EF CORE: "Migrations live in the UserApp.Database project"
        sqlOptions.MigrationsAssembly("UserApp.Database");
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoint to get all users
app.MapGet("/users", async (UserDbContext db) =>
    await db.Users.ToListAsync());

// Endpoint to create a new user
app.MapPost("/users", async (User user, UserDbContext db) =>
{
    // To avoid db overload allow to create only 100 users
    if (await db.Users.CountAsync() > 100)
    {
        return Results.Ok();
    }
    
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

app.MapDefaultEndpoints(); // Adds /health, /metrics, etc.

app.Run();