using System.Text.Json.Serialization;

namespace PetAdoptionAPI.Models;

public class MessageThread : BaseEntity 
{
    public int AdoptionRequestID { get; set; }
    [JsonIgnore]
    public AdoptionRequest? AdoptionRequest { get; set; }
    public ICollection<Message>? Messages { get; set; } = new List<Message>();
}