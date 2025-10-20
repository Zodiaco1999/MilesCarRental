using CleanArchitecture.Application;
using CleanArchitecture.Infraestructure;
using CleanArquitecture.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.ApplyMigration();
app.UseCustomExceptionHandler();
//app.SeedData();

app.MapControllers();

await app.RunAsync();
