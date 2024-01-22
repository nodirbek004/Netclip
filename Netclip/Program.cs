using Netclip.Application;
using Netclip.Infrastructure;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddAplication();
builder.Services.AddInfrastructure(builder.Configuration);  
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "qales",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200", "http://5.182.26.53")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("qales");

app.UseAuthorization();

app.MapControllers();

app.Run();
