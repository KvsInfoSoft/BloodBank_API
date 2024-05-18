using BloodBank_Api.Configuration;
using BloodBank_Api.Middleware;
using BloodBank_DBConfiguration.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AdoConnectionProvider(builder.Configuration); //This database connection
builder.Services.Add(new ServiceDescriptor(typeof(AdoContext), new AdoContext(builder.Configuration["ConnectionStrings:connection"])));
builder.Services.ConfigureRepositeries(); //for Interface and services
builder.Services.ConfigureServices(); // dependency injection 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors(o => o.WithOrigins("http://localhost:3000")
//.AllowAnyHeader()
//.AllowAnyMethod());
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
