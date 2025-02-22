using PetAdoptionAPI.Models;

public interface IPetService 
{
    Task<IEnumerable<Pet>> GetAllPetsAsync();
    Task<Pet?> GetPetByIdAsync(int id);
    Task<Pet> AddPetAsync(Pet pet);
    Task<bool> UpdatePetAsync(Pet pet);
    Task<bool> DeletePetAsync(int id);

    
}