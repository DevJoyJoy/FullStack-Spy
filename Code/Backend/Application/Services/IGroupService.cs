using Backend.Application.Features.Group.CreateGroup;
using Backend.Domain.Models;

namespace Backend.Application.Services;

public interface IGroupService
{
    Task<Grupo> GetByLink(string link);
    Task<Grupo> CreateGroup(CreateGroupPayload payload);
}