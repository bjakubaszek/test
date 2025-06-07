using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Exceptions;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controlers;

[ApiController]
[Route("[Controller]")]
public class PolitycyController (IDbService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPolityk()
    {
        return Ok(await service.GetPolitykDetails());
    }


    [HttpPost]
    public async Task<IActionResult> AddPolityk([FromBody] CreatePolitykRequest request)
    {
        try
        {
            var polityk = await service.CreatePolityk(request);
            return Created($"polityk/{polityk.Id}", polityk);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}