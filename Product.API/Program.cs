using Microsoft.EntityFrameworkCore;
using Serilog;
using Product.Data.Context;
using Product.Data.Extensions;
using Product.Service.Extensions;
using Product.Core.Extension;
using Product.Core.GeneralHelper;
using Product.API.Extension;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductEFContext>(opp => opp.UseSqlServer("Server=DESKTOP-4O79Q62;Initial Catalog=Product;Trusted_Connection=True;User Id=sa;Password=.;TrustServerCertificate=True"));
builder.Services.AddControllers();
builder.Services.RegisterDataLayer(builder.Configuration);
builder.Services.RegisterServiceLayer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ILoggingService, LoggingService>();
LoggingConfig.ConfigureLogging();
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
