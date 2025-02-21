namespace PetAdoptionAPI.Models;

public class Message : BaseEntity 
{
    public int MessageThreadID { get; set; }
    public MessageThread MessageThread { get; set; } = null!;

    public int SenderID { get; set; }

    public string Content { get; set; } = string.Empty;
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
}