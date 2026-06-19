using Backend.Application.Services;
using Backend.Domain.Models;

namespace Backend.Application.Features.Group.CreateGroup;

public class ChangeGroupNameUseCase(
    IGroupService groupService
)
{
    public async Task<Result<string>> Do(ChangeGroupNamePayload payload)
    {
        Grupo group = (await groupService.GetById(payload.GroupID)).data;

        group.Nome = payload.Name;

        return Result<string>.Success("Group name updated.");
    }
}