using Backend.Application.Services;
using Backend.Domain.Models;

namespace Backend.Application.Features.User.ChangeDataAccount;

public class ChangeDataAccountUseCase(
    IUserService userService
)
{
    public async Task<Result<Usuario>> Do( ChangeDataAccountPayload payload)
    {
        Result<Usuario> result = await userService.GetUserById(payload.Id);

        if(!result.IsSuccess)
            return Result<Usuario>.Fail("User not found");

        Usuario user = result.data!;

        if(payload.Name is not null)
            user.Nome = payload.Name;
        
        if(payload.Icon is not null)
            user.Icon = payload.Icon;

        if(payload is null)
            return Result<Usuario>.Fail("Campos nulos");

        return Result<Usuario>.Success(user);
    
    }
    
}