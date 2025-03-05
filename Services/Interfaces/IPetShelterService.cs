using PetAdoptionAPI.Models;

namespace PetAdoptionAPI.Services.Interfaces;

public interface IPetShelterService
{
    Task<IEnumerable<PetShelter>> GetAllPetSheltersAsync();
    Task<PetShelter?> GetPetShelterByIdAsync(int id);
    Task<PetShelter> AddPetShelterAsync(PetShelter petShelter);
    Task<bool> UpdatePetShelterAsync(PetShelter petShelter);
    Task<bool> DeletePetShelterAsync(int id);
}