using Backend.Application.Features.GetByLinkDTO;
using Backend.Application.Features.Group.CreateGroup;
using Backend.Domain.Models;

namespace Backend.Application.Services;

public interface IGroupService
{
    Task<Result<GetBylinkDTO>> GetByLink(string link);
    Task<Result<Grupo>> GetById(int id);
    Task<Result<CreateGroupResponse>> CreateGroup(CreateGroupPayload payload);
}