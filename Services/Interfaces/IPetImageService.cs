using PetAdoptionAPI.Models;

namespace PetAdoptionAPI.Services.Interfaces;
public interface IPetImageService
{
    Task<IEnumerable<PetImage>> GetAllImagesAsync();
    Task<IEnumerable<PetImage>> GetImagesByPetIdAsync(int petId);
    Task<PetImage?> GetImageByIdAsync(int id);
    Task<PetImage> AddImageAsync(PetImage petImage);
    Task<bool> DeleteImageAsync(int id);
}