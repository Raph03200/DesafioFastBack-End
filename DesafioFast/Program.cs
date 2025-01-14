using DesafioFast.DataContext;
using DesafioFast.Interfaces;
using DesafioFast.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();

builder.Services.AddScoped<WorkshopInterface, WorkshopService>();
builder.Services.AddScoped<ColaboradorInterface, ColaboradorService>();
builder.Services.AddScoped<PresencaInterface, PresencaService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cors =>
{
    cors.AllowAnyOrigin();
    cors.AllowAnyMethod();
    cors.AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
