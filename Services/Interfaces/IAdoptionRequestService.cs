using PetAdoptionAPI.Models;

namespace PetAdoptionAPI.Services.Interfaces;

public interface IAdoptionRequestService
{
    Task<IEnumerable<AdoptionRequest>> GetAllRequestsAsync();
    Task<AdoptionRequest?> GetRequestByIdAsync(int id);
    Task<IEnumerable<AdoptionRequest>> GetRequestsByUserIdAsync(int userId);
    Task<IEnumerable<AdoptionRequest>> GetRequestsByShelterIdAsync(int shelterId);
    Task<AdoptionRequest> CreateRequestAsync(AdoptionRequest request);
    Task<bool> UpdateRequestStatusAsync(int id, AdoptionRequestStatus status);
    Task<bool> DeleteRequestAsync(int id);
}