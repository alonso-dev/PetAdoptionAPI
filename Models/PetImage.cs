namespace PetAdoptionAPI.Models;

public class PetImage : BaseEntity 
{
    public string ImageURL { get; set; } = string.Empty;

    public int PetID { get; set; }
    public Pet Pet { get; set; } = null!;
}