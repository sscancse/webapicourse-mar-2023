var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Everything above is configuring "guts" - internals of API (services mostly)
var app = builder.Build();
// Everything below is configuring "http pipeline" - how API will handle requests and make responses

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/lunchtimes", () =>
{
    if ((DateTime.Now.Hour == 12 && DateTime.Now.Minute > 27))
    {
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.Run();
