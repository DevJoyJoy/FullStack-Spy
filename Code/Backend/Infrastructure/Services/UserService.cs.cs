using Backend.Application;
using Backend.Application.Features.User.CreateAccount;
using Backend.Application.Services;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Services;

public class UserService(SpyContext ctx) : IUserService
{
  
    public async Task<Result<CreateAccountResponse>> CreateAccount(CreateAccountPayload payload)
    {
        var user = await ctx.Usuarios.FirstOrDefaultAsync(u => u. Nome == payload.Name);
        
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