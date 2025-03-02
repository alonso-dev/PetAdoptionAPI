using System.Text.Json.Serialization;

namespace PetAdoptionAPI.Models;

public class PetImage : BaseEntity 
{
    public string ImageURL { get; set; } = string.Empty;
    public int PetID { get; set; }
    [JsonIgnore]
    public Pet? Pet { get; set; }
}