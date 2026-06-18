using Backend.Application;
using Backend.Application.Features.User.CreateAccount;
using Backend.Application.Features.User.DeleteAccount;
using Backend.Application.Services;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Services;

public class UserService(SpyContext ctx) : IUserService
{
  
    public async Task<Result<CreateAccountResponse>> CreateAccount(CreateAccountPayload payload)
    {
        var user = await ctx.Usuarios.FirstOrDefaultAsync(u => u. Nome == payload.Name);

        if(user is null) 
            return Result<CreateAccountResponse>.Fail("This user already exists!");

        Usuario newUser;
        if(payload.Icon is null)
            newUser = new Usuario(){
                Nome = payload.Name,
            };
        else
            newUser = new Usuario(){
                Nome = payload.Name,
                Icon = payload.Icon
            };

        ctx.Usuarios.Add(newUser);
        await ctx.SaveChangesAsync();

        return Result<CreateAccountResponse>.Success(new CreateAccountResponse()
        {
            Name = newUser.Nome,
            Icon = newUser.Icon
        });
    }

    public Task<Result<DeleteAccountResponse>> DeleteAccount(string Name)
    {
        
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