using PetAdoptionAPI.Models;

namespace PetAdoptionAPI.Services.Interfaces;
public interface IMessageThreadService
{
    Task<IEnumerable<MessageThread>> GetAllThreadsAsync();
    Task<MessageThread?> GetThreadByIdAsync(int id);
    Task<IEnumerable<MessageThread>> GetThreadsByUserIdAsync(int userId);
    Task<IEnumerable<MessageThread>> GetThreadsByShelterIdAsync(int shelterId);
    Task<MessageThread> CreateThreadAsync(MessageThread thread);
    Task<bool> DeleteThreadAsync(int id);
}
