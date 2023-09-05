var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Crear una lista para almacenar objetos
var categories = new List<Category>();

//
app.MapGet("/categories", () =>
{
    return categories;
});

//
app.MapPost("/categories", (Category category) =>
{
    categories.Add(category);
    return Results.Ok();
});

//APP RUN
app.Run();

internal class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Stock { get; set; }
}