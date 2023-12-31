//using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineShopping.Data;
using OnlineShopping.Infrastructure.Interfaces;
using OnlineShopping.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ShoppingConnectionString")
        )
    );

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

//builder.Services.AddAuthentication(option =>
//    {
//        option.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
//        option.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//    })
//    .AddGoogle(googleOption =>
//    {
//        googleOption.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//        googleOption.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        //Title = "OnlineShopping.WebApi",
        Title = "Online Shopping Api",
        Description = "An API application for managing Online Shopping Items",
        //TermsOfService = new Uri("https://example.com/terms"),
        //Contact = new OpenApiContact
        //{
        //    Name = "Example Contact",
        //    Url = new Uri("https://example.com/contact")
        //},
        //License = new OpenApiLicense
        //{
        //    Name = "Example License",
        //    Url = new Uri("https://example.com/license")
        //}
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
