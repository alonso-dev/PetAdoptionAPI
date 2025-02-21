namespace PetAdoptionAPI.Models;

public class PetShelter : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string ContactInfo { get; set; } = string.Empty;

    public int UserID { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Pet> Pets { get; set; } = null!;
}