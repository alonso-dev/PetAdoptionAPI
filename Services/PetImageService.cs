using Microsoft.EntityFrameworkCore;
using PetAdoptionAPI.Data;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Services;

public class PetImageService : IPetImageService
{
    private readonly ApplicationDbContext _context;

    public PetImageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PetImage>> GetAllImagesAsync()
    {
        return await _context.PetImages.ToListAsync();
    }

    public async Task<IEnumerable<PetImage>> GetImagesByPetIdAsync(int petId)
    {
        return await _context.PetImages
            .Where(img => img.PetID == petId)
            .ToListAsync();
    }

    public async Task<PetImage?> GetImageByIdAsync(int id)
    {
        return await _context.PetImages.FindAsync(id);
    }

    public async Task<PetImage> AddImageAsync(PetImage petImage)
    {
        _context.Attach(new Pet { ID = petImage.PetID });

        _context.PetImages.Add(petImage);
        await _context.SaveChangesAsync();
        return petImage;
    }

    public async Task<bool> DeleteImageAsync(int id)
    {
        var image = await _context.PetImages.FindAsync(id);
        if (image == null) return false;

        _context.PetImages.Remove(image);
        await _context.SaveChangesAsync();
        return true;
    }
}