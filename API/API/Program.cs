
using Dal.Seed;
using Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options => options.AddPolicy(name: "MusicLibraryAppOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ArtistCreateCommandHandler).Assembly));
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<DataContext>();
        context.Database.Migrate(); 

        // Check if the database is already seeded
        if (!context.Artists.Any())
        {
            var seedData = DataSeeder.LoadSeedData("data.json");

            var artists = seedData.Item1;
            var albums = seedData.Item2;
            var songs = seedData.Item3;

            // Add artists first
            context.Artists.AddRange(artists);
            await context.SaveChangesAsync();

            // Add albums next
            context.Albums.AddRange(albums);
            await context.SaveChangesAsync();

            // Add songs last
            context.Songs.AddRange(songs);
            await context.SaveChangesAsync();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the database.");
    }
}

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MusicLibraryAppOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
