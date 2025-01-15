using project_court_backend.Configuration;
using project_court_backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    var filePath = Path.Combine(AppContext.BaseDirectory, "project-court-backend.xml");
    s.IncludeXmlComments(filePath);
});

builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<CourtService>();
builder.Services.AddScoped<GradeService>();
builder.Services.AddScoped<SurfaceTypeService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dbContext.Database.Migrate();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

// To enable Swagger for API documentation when the backend is running in Docker
// This makes Swagger available regardless of the environment (e.g., Development, Production).
app.UseSwagger();
app.UseSwaggerUI();

// To enable Swagger only in the Development environment
// Uncomment this block to restrict Swagger access to Development mode for security reasons.
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();