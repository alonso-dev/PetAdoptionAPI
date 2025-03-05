using System.Text.Json.Serialization;

namespace PetAdoptionAPI.Models;

public class AdoptionRequest : BaseEntity 
{
    public int PetID { get; set; }
    [JsonIgnore]
    public Pet? Pet { get; set; }

    public int UserID { get; set; }
    [JsonIgnore]
    public User? User { get; set; }

    public AdoptionRequestStatus Status { get; set; } = AdoptionRequestStatus.Pending;

    public MessageThread? MessageThread { get; set; }
}

public enum AdoptionRequestStatus
{
    Pending,
    Approved,
    Rejected,
    Completed
}