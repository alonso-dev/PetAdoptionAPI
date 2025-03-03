using System.Text.Json.Serialization;

namespace PetAdoptionAPI.Models;

public class Message : BaseEntity 
{
    public int MessageThreadID { get; set; }
    [JsonIgnore]
    public MessageThread? MessageThread { get; set; }

    public int SenderID { get; set; }

    public string Content { get; set; } = string.Empty;
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
}