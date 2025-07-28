using Microsoft.AspNetCore.Mvc;
using Task2.Services.Interfaces;
using Task2.Services;
using Task2.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1?? Register your application services (DI container)
builder.Services.AddSingleton<IProductService, ProductService>();
// — so controllers can inject IProductService

// 2?? Add controllers and enable API versioning
builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});
// — supports v1, v2, etc. via URL (or header/query if you configure readers)

// 3?? Configure and enhance Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // add a swagger doc per API version
    c.SwaggerDoc("v1", new() { Title = "Sample API V1", Version = "v1" });
    c.SwaggerDoc("v2", new() { Title = "Sample API V2", Version = "v2" });
    // include XML comments if you have them:
    // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

// 4?? (Optional) Add middleware logging and exception handling services if they need DI
// — your middleware don’t need registration beyond ILogger, so no extra AddScoped/AddTransient here

var app = builder.Build();

// 5?? Configure the HTTP request pipeline

if (app.Environment.IsDevelopment())
{
    // expose both v1 & v2 swagger endpoints
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API V1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Sample API V2");
        c.RoutePrefix = string.Empty; // serve Swagger UI at root: /index.html
    });
}

// 6?? Global middleware
app.UseMiddleware<RequestLoggingMiddleware>();   // logs incoming requests
app.UseMiddleware<ErrorHandlingMiddleware>();   // catches exceptions and returns JSON

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();  // map attribute?decorated controllers (with versioned routes)

app.Run();
