using Microsoft.AspNetCore.Mvc;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdoptionRequestController : ControllerBase
{
    private readonly IAdoptionRequestService _adoptionRequestService;

    public AdoptionRequestController(IAdoptionRequestService adoptionRequestService)
    {
        _adoptionRequestService = adoptionRequestService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AdoptionRequest>>> GetAllRequests()
    {
        var requests = await _adoptionRequestService.GetAllRequestsAsync();
        return Ok(requests);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AdoptionRequest>> GetRequestById(int id)
    {
        var request = await _adoptionRequestService.GetRequestByIdAsync(id);
        if (request == null) return NotFound("Adoption request not found.");
        return Ok(request);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<AdoptionRequest>>> GetRequestsByUserId(int userId)
    {
        var requests = await _adoptionRequestService.GetRequestsByUserIdAsync(userId);
        return Ok(requests);
    }

    [HttpGet("shelter/{shelterId}")]
    public async Task<ActionResult<IEnumerable<AdoptionRequest>>> GetRequestsByShelterId(int shelterId)
    {
        var requests = await _adoptionRequestService.GetRequestsByShelterIdAsync(shelterId);
        return Ok(requests);
    }

    [HttpPost]
    public async Task<ActionResult<AdoptionRequest>> CreateRequest([FromBody] AdoptionRequest request)
    {
        if (request == null) return BadRequest("Invalid adoption request data.");

        var createdRequest = await _adoptionRequestService.CreateRequestAsync(request);
        return CreatedAtAction(nameof(GetRequestById), new { id = createdRequest.ID }, createdRequest);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateRequestStatus(int id, [FromBody] AdoptionRequestStatus status)
    {
        var updated = await _adoptionRequestService.UpdateRequestStatusAsync(id, status);
        if (!updated) return NotFound("Adoption request not found.");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRequest(int id)
    {
        var deleted = await _adoptionRequestService.DeleteRequestAsync(id);
        if (!deleted) return NotFound("Adoption request not found.");

        return NoContent();
    }
}