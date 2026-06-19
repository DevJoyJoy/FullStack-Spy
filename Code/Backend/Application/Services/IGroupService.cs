using Backend.Application.Features.GetByLinkDTO;
using Backend.Application.Features.Group.CreateGroup;
using Backend.Application.Features.Group.DeleteGroup;
using Backend.Application.Features.Group.JoinGroup;
using Backend.Domain.Models;

namespace Backend.Application.Services;

public interface IGroupService
{

    Task<Result<string>> AddMember(JoinGroupPayload payload);
    Task<Result<Grupo>> GetById(int id);
    Task<Result<CreateGroupResponse>> CreateGroup(CreateGroupPayload payload);
    Task<Result<string>> DeleteGroup(DeleteGroupPayload payload);
}