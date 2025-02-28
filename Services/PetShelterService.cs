using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetAdoptionAPI.Data;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Services;

public class PetShelterService : IPetShelterService
{
    private readonly ApplicationDbContext _context;

    public PetShelterService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PetShelter>> GetAllPetShelters()
    {
        return await _context.PetShelters
            .Include(ps => ps.Pets)
            .ToListAsync();
    }

    public async Task<PetShelter?> GetPetShelterByIdAsync(int id)
    {
        return await _context.PetShelters
            .Include( ps => ps.Pets)
            .FirstOrDefaultAsync( ps => ps.ID == id);
    }

    public async Task<PetShelter> AddPetShelterAsync(PetShelter petShelter)
    {
        _context.PetShelters.Add(petShelter);
        await _context.SaveChangesAsync();
        return petShelter;
    }

    public async Task<bool> UpdatePetShelterAsync(PetShelter petShelter)
    {
        var existingPetShelter = await _context.PetShelters.FindAsync(petShelter.ID);
        if(existingPetShelter == null) return false;

        _context.Entry(existingPetShelter).CurrentValues.SetValues(petShelter);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePetShelterAsync(int id)
    {
        var existingPetShelter = await _context.PetShelters.FindAsync(id);
        if (existingPetShelter == null) return false;

        _context.PetShelters.Remove(existingPetShelter);
        await _context.SaveChangesAsync();
        return true;
    }


}