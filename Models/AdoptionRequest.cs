namespace PetAdoptionAPI.Models;

public class AdoptionRequest : BaseEntity 
{
    public int PetID { get; set; }
    public Pet Pet { get; set; } = null!;

    public int UserID { get; set; }
    public User User { get; set; } = null!;

    public AdoptionRequestStatus Status { get; set; } = AdoptionRequestStatus.Pending;

    public MessageThread MessageThread { get; set; } = null!;
}

public enum AdoptionRequestStatus
{
    Pending,
    Approved,
    Rejected,
    Completed
}