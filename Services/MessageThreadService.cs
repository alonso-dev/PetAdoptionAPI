using Microsoft.EntityFrameworkCore;
using PetAdoptionAPI.Data;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Services;

public class MessageThreadService : IMessageThreadService
{
    private readonly ApplicationDbContext _context;

    public MessageThreadService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MessageThread>> GetAllThreadsAsync()
    {
        return await _context.MessageThreads
            .Include(mt => mt.Messages)
            .ToListAsync();
    }

    public async Task<MessageThread?> GetThreadByIdAsync(int id)
    {
        return await _context.MessageThreads
            .Include(mt => mt.Messages)
            .FirstOrDefaultAsync(mt => mt.ID == id);
    }

    public async Task<IEnumerable<MessageThread>> GetThreadsByUserIdAsync(int userId)
    {
        return await _context.MessageThreads
            .Where(mt => mt.AdoptionRequest.UserID == userId) 
            .Include(mt => mt.Messages)
            .ToListAsync();
    }

    public async Task<IEnumerable<MessageThread>> GetThreadsByShelterIdAsync(int shelterId)
    {
        return await _context.MessageThreads
            .Where(mt => mt.AdoptionRequest.Pet.PetShelterID == shelterId) 
            .Include(mt => mt.Messages)
            .ToListAsync();
    }

    public async Task<MessageThread> CreateThreadAsync(MessageThread thread)
    {
        _context.MessageThreads.Add(thread);
        await _context.SaveChangesAsync();
        return thread;
    }

    public async Task<bool> DeleteThreadAsync(int id)
    {
        var thread = await _context.MessageThreads.FindAsync(id);
        if (thread == null) return false;

        _context.MessageThreads.Remove(thread);
        await _context.SaveChangesAsync();
        return true;
    }
}
