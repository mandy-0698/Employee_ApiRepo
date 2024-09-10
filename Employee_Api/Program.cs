using Dapper;
using Employee_Api.Models;
using Employee_Api.Repository;
using Employee_Api.RSA;
using Employee_Api.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRSAHelper, RSAHelper>();


//Allowing CORS
string policyName = "CorsPolicy";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: policyName, builder =>
    {
        builder.AllowAnyOrigin()   //specify url which will be allowed for accessing the data
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors(policyName);
app.UseAuthorization();

app.MapControllers();

app.Run();
