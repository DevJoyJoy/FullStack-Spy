namespace Backend.Application.Services;

public interface IGroupService
{
    Task<Grupo> GetByLink(string link);
    Task<Grupo> CreateGroup(Grupo grupo);
}