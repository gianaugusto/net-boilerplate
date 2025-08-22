using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestApp.Application.Interfaces;
using TestApp.Application.Services;
using TestApp.Application.Validation;
using TestApp.Domain.Interfaces;
using TestApp.Infrastructure.Data;
using TestApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure Microsoft Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("TestAppDb"));

// Register services
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ItemValidator>();
builder.Services.AddScoped<LoggerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
