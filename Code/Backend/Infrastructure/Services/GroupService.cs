using Backend.Application.Services;
using Backend.Domain.Models;

namespace Backend.Infrastructure.Services;

public class GroupService : IGroupService
{
    public Task<Grupo> CreateGroup(Grupo grupo)
    {
        
    }

    public Task<Grupo> GetByLink(string link)
    {
        throw new NotImplementedException();
    }
}