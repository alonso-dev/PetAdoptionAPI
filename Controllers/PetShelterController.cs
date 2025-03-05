using Microsoft.AspNetCore.Mvc;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetShelterController : ControllerBase
{
    private readonly IPetShelterService _petShelterService;

    public PetShelterController(IPetShelterService petShelterService)
    {
        _petShelterService = petShelterService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PetShelter>>> GetAllPetShelters()
    {
        var petShelters = await _petShelterService.GetAllPetSheltersAsync();
        return Ok(petShelters);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PetShelter>> GetPetShelterById(int id)
    {
        var petShelter = await _petShelterService.GetPetShelterByIdAsync(id);
        if(petShelter == null) return NotFound("Pet Shelter not found.");

        return Ok(petShelter);
    }

    [HttpPost]
    public async Task<ActionResult<PetShelter>> AddPetShelter([FromBody] PetShelter petShelter)
    {
        if(petShelter == null) return BadRequest("Invalid pet shelter data.");

        var createdPetShelter = await _petShelterService.AddPetShelterAsync(petShelter);
        return CreatedAtAction(nameof(GetPetShelterById), new { id = createdPetShelter}, createdPetShelter);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePetShelter(int id, [FromBody] PetShelter petShelter)
    {
        if(id != petShelter.ID) return BadRequest("Pet shelter Id missmatch.");

        var updated = await _petShelterService.UpdatePetShelterAsync(petShelter);
        if(!updated) return NotFound("Pet Shelter not foud.");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePetShelter(int id)
    {
        var deleted = await _petShelterService.DeletePetShelterAsync(id);
        if(!deleted) return NotFound("Pet Shelter not found.");

        return NoContent();
    }
}