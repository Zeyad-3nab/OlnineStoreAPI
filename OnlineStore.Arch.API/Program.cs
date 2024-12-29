using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineStore.Arch.Core.IRepositories;
using OnlineStore.Arch.Core.Mapping.Products;
using OnlineStore.Arch.Core.Services;
using OnlineStore.Arch.Repository;
using OnlineStore.Arch.Repository.Data;
using OnlineStore.Arch.Repository.Data.Contexts;
using OnlineStore.Arch.Services.Services.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Connection String
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(m => m.AddProfile(new ProductProfile(builder.Configuration)));

var app = builder.Build();



//To Don't make update-database with deployment
using var scope = app.Services.CreateScope();
var services=scope.ServiceProvider;
var context = services.GetRequiredService<ApplicationDbContext>();
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
try
{
    await context.Database.MigrateAsync();
    await ApplicationDbContextSeed.SeedAsync(context);

}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "There are problems during apply migrations !");
}






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
