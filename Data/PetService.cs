using PetAdoptionAPI.Models;

namespace PetAdoptionAPI.Data;

public static class PetService
{
    static List<Pet> Pets { get; }
    static int nextId = 4;

    static PetService()
    {
        Pets = new List<Pet>
        {
            new Pet{Id = 1, Name = "Marley", Age = 18, Breed = "Winner", ImageUrl = "marley.com"},
            new Pet{Id = 2, Name = "Tatto", Age = 80, Breed = "Zagua", ImageUrl = "tatto.com"},
            new Pet{Id = 3, Name = "Fluffy", Age = 60, Breed = "Chipu", ImageUrl = "fluffy.com"}
        };
    }

    public static List<Pet> GetAll() => Pets;

    public static Pet? Get(int id) => Pets.FirstOrDefault( pet => pet.Id == id);

    public static void Add(Pet pet)
    {
        pet.Id = nextId++;
        Pets.Add(pet);
    }

    public static void Delete(int id)
    {
       var pet = Get(id);
        if(pet is null)
            return;
        
        Pets.Remove(pet);
    }

    public static void Update(Pet pet)
    {
         var index = Pets.FindIndex(p => p.Id == pet.Id);
         if(index == -1)
            return;
        
        Pets[index] = pet;
    }
}