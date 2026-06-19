using Backend.Application.Services;

namespace Backend.Application.Features.Group.DeleteGroup;

public class DeleteGroupUseCase(
    IGroupService groupService
)
{
    public async Task<Result<string>> Do(DeleteGroupPayload payload)
    {
        return await groupService.DeleteGroup(payload);
    }
}