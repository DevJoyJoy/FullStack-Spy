using System.Reflection.Metadata.Ecma335;
using Backend.Application.Services;

namespace Backend.Application.Features.Group.JoinGroup;
public class JoinGroupUseCase(
    IGroupService groupService
)
{
    public async Task<Result<string>> Do(JoinGroupPayload payload)
    {
        return await groupService.AddMember(payload);
    }
}