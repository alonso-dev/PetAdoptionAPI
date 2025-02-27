using Microsoft.AspNetCore.Mvc;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase
{
    private readonly IPetService _petService;

    public PetController(IPetService petService)
    {
        _petService = petService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> GetAllPets()
    {
        var pets = await _petService.GetAllPetsAsync();
        return Ok(pets);
    } 

    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetPetById(int id)
    {
        var pet = await _petService.GetPetByIdAsync(id);
        if (pet == null) return NotFound("Pet not found.");
        return Ok(pet);
    }

    [HttpPost]
    public async Task<ActionResult<Pet>> AddPet([FromBody] Pet pet)
    {
        if(pet == null) return BadRequest("Invalid pet data.");

        var createdPet = await _petService.AddPetAsync(pet);
        return CreatedAtAction(nameof(GetPetById), new { id = createdPet.ID});
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePet(int id, [FromBody] Pet pet)
    {
        if(id != pet.ID) return BadRequest("Pet ID mismatch");

        var updated = await _petService.UpdatePetAsync(pet);
        if(!updated) return NotFound("Pet not found.");

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePet(int id)
    {
        var deleted = await _petService.DeletePetAsync(id);
        if (!deleted) return NotFound("Pet not found.");

        return NoContent();
    }


}