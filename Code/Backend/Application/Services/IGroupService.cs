using Backend.Domain.Models;

namespace Backend.Application.Services;

public interface GroupService
{
    Task<Grupo> GetByLink(string link);
    Task<Grupo> CreateGroup(Grupo grupo);
}