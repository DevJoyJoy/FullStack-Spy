using Backend.Application;
using Backend.Application.Features.Location.CreateLocation;
using Backend.Application.Features.Location.GetLastLocationByUserId;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controller;

[ApiController]
[Route("/Location")]
public class LocationController(
    GetLastLocationByUserIdUseCase lastlocationUseCase,
    CreateLocationUseCase createLocationUseCase
) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLocation(
        [FromBody] CreateLocationPayload payload
    )
    {
        var response = await createLocationUseCase.Do(payload);

        if(!response.IsSuccess)
            return BadRequest(response);
        
        return Ok(response.data);
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetLastLocation(
        [FromRoute] int id
    )
    {
        var response = await lastlocationUseCase.Do(id);

        if(!response.IsSuccess)
            return BadRequest(response);
        
        return Ok(response.data);
    }
}