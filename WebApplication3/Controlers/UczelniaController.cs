using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Exceptions;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controlers;

[ApiController]
[Route("api/[Controller]")]
public class EnrollmentsController (IDbService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetStudent()
    {
        return Ok(await service.GetStudentDetails());
    }


    [HttpPost]
    public async Task<IActionResult> AddCourseWithEnrollments([FromBody] CreateCourseRequest request)
    {
        try
        {
            /*var polityk = await service.CreatePolityk(request);
            return Created($"polityk/{polityk.Id}", polityk);*/

            await service.CreateCourseWithEnroll(request);
            return null;
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}