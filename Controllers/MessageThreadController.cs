using Microsoft.AspNetCore.Mvc;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageThreadController : ControllerBase
{
    private readonly IMessageThreadService _messageThreadService;

    public MessageThreadController(IMessageThreadService messageThreadService)
    {
        _messageThreadService = messageThreadService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MessageThread>>> GetAllThreads()
    {
        var threads = await _messageThreadService.GetAllThreadsAsync();
        return Ok(threads);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MessageThread>> GetThreadById(int id)
    {
        var thread = await _messageThreadService.GetThreadByIdAsync(id);
        if (thread == null) return NotFound("Message thread not found.");
        return Ok(thread);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<MessageThread>>> GetThreadsByUserId(int userId)
    {
        var threads = await _messageThreadService.GetThreadsByUserIdAsync(userId);
        return Ok(threads);
    }

    [HttpGet("shelter/{shelterId}")]
    public async Task<ActionResult<IEnumerable<MessageThread>>> GetThreadsByShelterId(int shelterId)
    {
        var threads = await _messageThreadService.GetThreadsByShelterIdAsync(shelterId);
        return Ok(threads);
    }

    [HttpPost]
    public async Task<ActionResult<MessageThread>> CreateThread([FromBody] MessageThread thread)
    {
        if (thread == null) return BadRequest("Invalid message thread data.");

        var createdThread = await _messageThreadService.CreateThreadAsync(thread);
        return CreatedAtAction(nameof(GetThreadById), new { id = createdThread.ID }, createdThread);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteThread(int id)
    {
        var deleted = await _messageThreadService.DeleteThreadAsync(id);
        if (!deleted) return NotFound("Message thread not found.");

        return NoContent();
    }
}