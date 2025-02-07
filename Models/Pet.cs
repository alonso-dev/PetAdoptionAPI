namespace PetAdoptionAPI.Models;

public class Pet
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Breed { get; set; }
    public int Age { get; set; }
    public string? ImageUrl { get; set; }
}