using System.Text.RegularExpressions;
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
        var user = await ctx.Usuarios.FirstOrDefaultAsync(u => u.Nome == payload.Name);

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

    public async Task<Result<string>> DeleteAccount(string Name)
    {
        
        var user = await ctx.Usuarios.FirstOrDefaultAsync(u => u.Nome == Name );

        if(user is null)
            return Result<string>.Fail("User is null");
        
        if(Name is null)
            return Result<string>.Fail("Name is null");

        ctx.Usuarios.Remove(user);

        await ctx.SaveChangesAsync();

        return Result<string>.Success("Usuario deletado");

    
    }

    public async Task<Result<Usuario>> GetUserById(int Id)
    {
        var user = await ctx.Usuarios.FirstOrDefaultAsync(u => u.Id == Id);
        if(user is null)
            return Result<Usuario>.Fail("User not found");

        return Result<Usuario>.Success(user);
    }

    public async Task<Result<CreateAccountResponse>> GetUserByName(string Name_)
    {
        var user = await ctx.Usuarios.FirstOrDefaultAsync(u => u.Nome == Name_);
        if(user is null)
            return Result<CreateAccountResponse>.Fail("User is null");

        if(Name_ is null)
            return Result<CreateAccountResponse>.Fail("Name is null");

        await ctx.SaveChangesAsync();

        return Result<CreateAccountResponse>.Success(new CreateAccountResponse()
        {
            Name = user.Nome,
            Icon = user.Icon
        });
        
    }

    public async Task<Result<List<Grupo>>> ViewGroupByName(string Name)
    {

        if(Name is null)
            return Result<List<Grupo>>.Fail("Name is null");

        var user = await ctx
            .Usuarios
            .Include(u => u.Grupos)
            .FirstOrDefaultAsync(u => u.Nome == Name);
        
        if(user is null)
            return Result<List<Grupo>>.Fail("User is null");

        List<Grupo> Grupo = user.Grupos
            .ToList();

        return Result<List<Grupo>>.Success(Grupo);
        
    }

    Task<Result<DeleteAccountResponse>> IUserService.DeleteAccount(string Name)
    {
        throw new NotImplementedException();
    }
}