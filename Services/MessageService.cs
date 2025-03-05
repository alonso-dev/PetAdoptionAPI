using Microsoft.EntityFrameworkCore;
using PetAdoptionAPI.Data;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Services;

public class MessageService : IMessageService
{
    private readonly ApplicationDbContext _context;

    public MessageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Message>> GetAllMessagesAsync()
    {
        return await _context.Messages.ToListAsync();
    }

    public async Task<IEnumerable<Message>> GetMessagesByThreadIdAsync(int threadId)
    {
        return await _context.Messages
            .Where(m => m.MessageThreadID == threadId)
            .ToListAsync();
    }

    public async Task<Message?> GetMessageByIdAsync(int id)
    {
        return await _context.Messages.FindAsync(id);
    }

    public async Task<Message> AddMessageAsync(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        return message;
    }

    public async Task<bool> DeleteMessageAsync(int id)
    {
        var message = await _context.Messages.FindAsync(id);
        if (message == null) return false;

        _context.Messages.Remove(message);
        await _context.SaveChangesAsync();
        return true;
    }
}