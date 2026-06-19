using Backend.Application.Services;
using Backend.Domain.Models;

namespace Backend.Application.Features.Group.CreateGroup;

public class CreateGroupUseCase(
    IGroupService groupService
)
{
    public async Task<Result<CreateGroupResponse>> Do(CreateGroupPayload payload)
    {
        return await groupService.CreateGroup(payload);
    }
}