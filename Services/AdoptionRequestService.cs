using Microsoft.EntityFrameworkCore;
using PetAdoptionAPI.Data;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Services;

public class AdoptionRequestService : IAdoptionRequestService
{
    private readonly ApplicationDbContext _context;

    public AdoptionRequestService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AdoptionRequest>> GetAllRequestsAsync()
    {
        return await _context.AdoptionRequests
            .Include(ar => ar.Pet)
            .Include(ar => ar.User)
            .ToListAsync();
    }

    public async Task<AdoptionRequest?> GetRequestByIdAsync(int id)
    {
        return await _context.AdoptionRequests
            .Include(ar => ar.Pet)
            .Include(ar => ar.User)
            .FirstOrDefaultAsync(ar => ar.ID == id);
    }

    public async Task<IEnumerable<AdoptionRequest>> GetRequestsByUserIdAsync(int userId)
    {
        return await _context.AdoptionRequests
            .Where(ar => ar.UserID == userId)
            .Include(ar => ar.Pet)
            .ToListAsync();
    }

    public async Task<IEnumerable<AdoptionRequest>> GetRequestsByShelterIdAsync(int shelterId)
    {
        return await _context.AdoptionRequests
            .Where(ar => ar.Pet.PetShelterID == shelterId)
            .Include(ar => ar.Pet)
            .ToListAsync();
    }

    public async Task<AdoptionRequest> CreateRequestAsync(AdoptionRequest request)
    {
        _context.AdoptionRequests.Add(request);
        await _context.SaveChangesAsync();
        return request;
    }

    public async Task<bool> UpdateRequestStatusAsync(int id, AdoptionRequestStatus status)
    {
        var request = await _context.AdoptionRequests.FindAsync(id);
        if (request == null) return false;

        request.Status = status;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteRequestAsync(int id)
    {
        var request = await _context.AdoptionRequests.FindAsync(id);
        if (request == null) return false;

        _context.AdoptionRequests.Remove(request);
        await _context.SaveChangesAsync();
        return true;
    }
}