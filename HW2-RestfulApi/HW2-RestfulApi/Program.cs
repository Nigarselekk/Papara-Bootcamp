using HW2_RestfulApi.Extensions;
using HW2_RestfulApi.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.Use(async (context, next) =>
{
    Console.WriteLine($"[LOG] Request: {context.Request.Method} {context.Request.Path}");
    await next();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();