using PetAdoptionAPI.Models;

namespace PetAdoptionAPI.Services.Interfaces;

public interface IMessageService
{
    Task<IEnumerable<Message>> GetAllMessagesAsync();
    Task<IEnumerable<Message>> GetMessagesByThreadIdAsync(int threadId);
    Task<Message?> GetMessageByIdAsync(int id);
    Task<Message> AddMessageAsync(Message message);
    Task<bool> DeleteMessageAsync(int id);
}