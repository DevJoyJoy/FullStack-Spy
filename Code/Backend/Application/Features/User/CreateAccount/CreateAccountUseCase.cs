using Backend.Application.Services;

namespace Backend.Application.Features.User.CreateAccount;
public class CreateAccountUseCase(
    IUserService userService
)
{
    public async Task<Result<CreateAccountResponse>> Do(CreateAccountPayload payload)
    {
        var result = await userService.CreateAccount( new CreateAccountPayload
        {
            Name = payload.Name,
            Icon = payload.Icon
        });
        
        if(!result.IsSuccess)
            return Result<CreateAccountResponse>.Fail("User not found");
        
        return Result<CreateAccountResponse>.Success(new CreateAccountResponse()
        {
            Name = result.data.Name, 
            Icon = result.data.Icon
        });

    }
    
}