using Microsoft.EntityFrameworkCore;
using PetAdoptionAPI.Data;
using PetAdoptionAPI.Models;

public class PetService : IPetService
{
    private readonly ApplicationDbContext _context;

    public PetService(ApplicationDbContext context){
        _context = context;
    }

    public async Task<IEnumerable<Pet>> GetAllPetsAsync()
    {
        return await _context.Pets
                .Include(p => p.PetShelter)
                .Include(p => p.Images)
                .ToListAsync();
    }

    public async Task<Pet?> GetPetByIdAsync(int id)
    {
        return await _context.Pets.Include(p => p.Images).FirstOrDefaultAsync(p => p.ID == id);
    }

    public async Task<Pet> AddPetAsync(Pet pet)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task<bool> UpdatePetAsync(Pet pet)
    {
        var existingPet = await _context.Pets.FindAsync(pet.ID);
        if(existingPet == null) return false;

        _context.Entry(existingPet).CurrentValues.SetValues(pet);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePetAsync(int id)
    {
        var pet = await _context.Pets.FindAsync(id);
        if (pet == null) return false;

        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
        return true;
    }

}