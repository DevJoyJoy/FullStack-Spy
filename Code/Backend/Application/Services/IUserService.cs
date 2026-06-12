namespace Backend.Application.Services;

using Backend.Domain.Models;
public interface IUserService
{
    Task<Usuario> CreateAccount(Usuario user);
    Task<Usuario> DeleteAccount(string Name);
    Task<Usuario> ViewGroupByName(string Name);
    Task<Usuario> GetUserByName(string Name);

}