// Program.cs
using AnimalAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Animal> animals = new List<Animal>
{
    new Animal { Id = 1, Name = "Rex", Category = "Dog", Weight = 30.5, FurColor = "Brown" },
    new Animal { Id = 2, Name = "Mia", Category = "Cat", Weight = 4.5, FurColor = "Black" }
};

// GET all animals
app.MapGet("/animals", () => animals);

// GET an animal by ID
app.MapGet("/animals/{id}", (int id) =>
{
    var animal = animals.FirstOrDefault(a => a.Id == id);
    return animal is not null ? Results.Ok(animal) : Results.NotFound();
});

// POST a new animal
app.MapPost("/animals", (Animal animal) =>
{
    animals.Add(animal);
    return Results.Created($"/animals/{animal.Id}", animal);
});

// PUT update an animal
app.MapPut("/animals/{id}", (int id, Animal updatedAnimal) =>
{
    var index = animals.FindIndex(a => a.Id == id);
    if (index == -1)
    {
        return Results.NotFound();
    }
    animals[index] = updatedAnimal;
    return Results.NoContent();
});

// DELETE an animal
app.MapDelete("/animals/{id}", (int id) =>
{
    var index = animals.FindIndex(a => a.Id == id);
    if (index == -1)
    {
        return Results.NotFound();
    }
    animals.RemoveAt(index);
    return Results.NoContent();
});

app.Run();