using System.Text.Json.Serialization;

namespace PetAdoptionAPI.Models;

public class Pet : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Breed { get; set; } = string.Empty;    
    public string Description { get; set; } = string.Empty;
    public PetStatus Status { get; set; } = PetStatus.Available;

    public int PetShelterID { get; set; }
    
    [JsonIgnore]
    public PetShelter? PetShelter { get; set; }

    public ICollection<PetImage>? Images { get; set; } = new List<PetImage>();
}
public enum PetStatus 
{
    Available,
    Adopted,
    Pending
}
