using Microsoft.AspNetCore.Mvc;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

namespace PetAdoptionAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> GetAllMessages()
    {
        var messages = await _messageService.GetAllMessagesAsync();
        return Ok(messages);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessageById(int id)
    {
        var message = await _messageService.GetMessageByIdAsync(id);
        if (message == null) return NotFound("Message not found.");
        return Ok(message);
    }

    [HttpGet("thread/{threadId}")]
    public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByThreadId(int threadId)
    {
        var messages = await _messageService.GetMessagesByThreadIdAsync(threadId);
        return Ok(messages);
    }

    [HttpPost]
    public async Task<ActionResult<Message>> AddMessage([FromBody] Message message)
    {
        if (message == null) return BadRequest("Invalid message data.");

        var createdMessage = await _messageService.AddMessageAsync(message);
        return CreatedAtAction(nameof(GetMessageById), new { id = createdMessage.ID }, createdMessage);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
        var deleted = await _messageService.DeleteMessageAsync(id);
        if (!deleted) return NotFound("Message not found.");

        return NoContent();
    }
}