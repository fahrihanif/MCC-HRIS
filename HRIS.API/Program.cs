using HRIS.API.Extensions;
using HRIS.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHrisServices();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<ITransientOperation, Operation>();   // a new instance for every injection
builder.Services.AddScoped<IScopedOperation, Operation>();         // one instance per HTTP request
builder.Services.AddSingleton<ISingletonOperation, Operation>();   // one instance for the application
builder.Services.AddScoped<OperationReport>();                     // helper 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "HRIS API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();