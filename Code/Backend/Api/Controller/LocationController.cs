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
    public async Task<Result<CreateLocationResponse>> CreateLocation(
        [FromRoute] int id
    )
    {
        var response = createLocationUseCase.Do
        
    }
}