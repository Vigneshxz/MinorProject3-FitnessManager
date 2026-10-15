
using MinorProject3.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages services.
builder.Services.AddRazorPages();

// Read the MySQL connection string from configuration.
var connectionString = builder.Configuration.GetConnectionString("FitnessManager")
    ?? throw new InvalidOperationException(
        "FitnessManager connection string was not found.");

// Register our separate data-layer connection factory.
builder.Services.AddSingleton(
    new DbConnectionFactory(connectionString));
// Register the client repository.
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<TrainerRepository>();
builder.Services.AddScoped<ExerciseRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
