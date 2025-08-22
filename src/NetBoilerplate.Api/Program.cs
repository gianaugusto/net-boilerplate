using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetBoilerplate.Application.Interfaces;
using NetBoilerplate.Application.Services;
using NetBoilerplate.Application.Validation;
using NetBoilerplate.Domain.Interfaces;
using NetBoilerplate.Infrastructure.Data;
using NetBoilerplate.Infrastructure.Repositories;

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
    options.UseInMemoryDatabase("NetBoilerplateDb"));

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
