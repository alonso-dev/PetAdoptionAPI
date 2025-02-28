namespace PetAdoptionAPI.Models;

public class MessageThread : BaseEntity 
{
    public int AdoptionRequestID { get; set; }
    public AdoptionRequest AdoptionRequest { get; set; } = null!;

    public ICollection<Message>? Messages { get; set; } = new List<Message>();
}