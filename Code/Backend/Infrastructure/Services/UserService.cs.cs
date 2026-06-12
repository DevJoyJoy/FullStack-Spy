using Backend.Application.Services;
using Backend.Domain.Models;

namespace Backend.Infrastructure.Services;

public class UserService : IUserService
{
    public Task<Usuario> CreateAccount(Usuario user)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> DeleteAccount(string Name)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> GetUserByName(string Name)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> ViewGroupByName(string Name)
    {
        throw new NotImplementedException();
    }
}