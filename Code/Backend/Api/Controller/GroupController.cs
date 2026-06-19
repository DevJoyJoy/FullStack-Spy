using Backend.Application.Features.Group.CreateGroup;
using Backend.Application.Features.Group.DeleteGroup;
using Backend.Application.Features.Group.JoinGroup;
using Backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupService groupService) : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> ChangeGroupName(
        [FromBody] ChangeGroupNamePayload payload,
        [FromServices] ChangeGroupNameUseCase usecase
    ) 
    {
        var result = await usecase.Do(payload);
        return (result.IsSuccess, result.reason) switch
            {
                (false, "Error") => NotFound(),
                (false, _) => BadRequest(),
                (true, _) => Ok(result.data)
            };
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateGroup(
        [FromServices] CreateGroupUseCase useCase,
        [FromBody] CreateGroupPayload payload
    )
    {
        var result = await useCase.Do(payload);
        return (result.IsSuccess, result.reason) switch
        {
            (false, "error") => NotFound(),
            (false, _) => BadRequest(),
            (true, _) => Ok(result.data)
        };
    }
    
    [HttpPost]
    public async Task<IActionResult> JoinGroup(
        [FromBody] JoinGroupPayload payload,
        [FromServices] JoinGroupUseCase usecase
    )
    {
        var result = await usecase.Do(payload);

        return (result.IsSuccess, result.reason) switch
        {
            (false, "Error") => NotFound(),
            (false, _) => BadRequest(),
            (true, _) => Ok(result.data)
        };
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteGroup(
        [FromBody] DeleteGroupPayload payload,
        [FromServices] DeleteGroupUseCase usecase
    )
    {
        var result = await usecase.Do(payload);

        return (result.IsSuccess, result.reason) switch
        {
            (false, "Error") => NotFound(),
            (false, _) => BadRequest(),
            (true,_) => Ok(result.data)
        };
    }
}