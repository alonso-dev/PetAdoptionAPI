using Microsoft.AspNetCore.Mvc;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetImageController : ControllerBase
{
    private readonly IPetImageService _petImageService;

    public PetImageController(IPetImageService petImageService)
    {
        _petImageService = petImageService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PetImage>>> GetAllImages()
    {
        var images = await _petImageService.GetAllImagesAsync();
        return Ok(images);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PetImage>> GetImageById(int id)
    {
        var image = await _petImageService.GetImageByIdAsync(id);
        if (image == null) return NotFound("Image not found.");
        return Ok(image);
    }

    [HttpGet("pet/{petId}")]
    public async Task<ActionResult<IEnumerable<PetImage>>> GetImagesByPetId(int petId)
    {
        var images = await _petImageService.GetImagesByPetIdAsync(petId);
        return Ok(images);
    }

    [HttpPost]
    public async Task<ActionResult<PetImage>> AddImage([FromBody] PetImage petImage)
    {
        if (petImage == null) return BadRequest("Invalid image data.");

        var createdImage = await _petImageService.AddImageAsync(petImage);
        return CreatedAtAction(nameof(GetImageById), new { id = createdImage.ID }, createdImage);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
        var deleted = await _petImageService.DeleteImageAsync(id);
        if (!deleted) return NotFound("Image not found.");

        return NoContent();
    }
}