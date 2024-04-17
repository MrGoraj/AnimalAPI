namespace AnimalAPI;

using System;
using System.Collections.Generic;
using System.Linq;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string FurColor { get; set; }
    public List<Visit> Visits { get; set; } = new List<Visit>();
}

public class Visit
{
    public DateTime Date { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
}

public class AnimalManager
{
    private List<Animal> animals = new List<Animal>();
    
    public List<Animal> GetAllAnimals()
    {
        return animals;
    }
    
    public Animal GetAnimalById(int id)
    {
        return animals.FirstOrDefault(a => a.Id == id);
    }
    
    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }
    
    public void EditAnimal(int id, Animal updatedAnimal)
    {
        var animal = GetAnimalById(id);
        if (animal != null)
        {
            animal.Name = updatedAnimal.Name;
            animal.Category = updatedAnimal.Category;
            animal.Weight = updatedAnimal.Weight;
            animal.FurColor = updatedAnimal.FurColor;
        }
    }
    
    public void DeleteAnimal(int id)
    {
        animals.RemoveAll(a => a.Id == id);
    }
    
    public List<Visit> GetVisitsByAnimalId(int animalId)
    {
        return animals.FirstOrDefault(a => a.Id == animalId)?.Visits;
    }
    
    public void AddVisit(int animalId, Visit visit)
    {
        Animal animal = GetAnimalById(animalId);
        if (animal != null)
        {
            animal.Visits.Add(visit);
        }
    }
}
