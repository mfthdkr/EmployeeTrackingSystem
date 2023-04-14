using Autofac;
using Autofac.Extensions.DependencyInjection;
using EmployeeTrackingSystem.BusinessLayer.Mapping;
using EmployeeTrackingSystem.BusinessLayer.Validations.Employee;
using EmployeeTrackingSystem.DataAccessLayer.EntityFramework.Context;
using EmployeeTrackingSystem.WebAPI.Filter;
using EmployeeTrackingSystem.WebAPI.Middlewares;
using EmployeeTrackingSystem.WebAPI.Modules;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<EmployeeDtoValidator>());
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// NotFoundFilter
builder.Services.AddScoped(typeof(NotFoundFilter<,>));

// Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<EmployeeTrackingSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepositoryAndServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();


app.MapControllers();

app.Run();