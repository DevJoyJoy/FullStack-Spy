using Backend.Application.Features.User.CreateAccount;
using Backend.Application.Services;

namespace Backend.Application.Features.User.ChangeDataAccount;

public class ChangeDataAccountUseCase(
    IUserService userService
)
{
    public async Task<Result<CreateAccountResponse>> Do( CreateAccountPayload payload)
    {
        Result<CreateAccountResponse> result = await userService.GetUserByName(payload.Name);

        if(!result.IsSuccess)
            return Result<CreateAccountResponse>.Fail("result not found");

        return Result<CreateAccountResponse>.Success(new CreateAccountResponse()
        {
            Name = result.data.Name, 
            Icon = result.data.Icon
        });
    
    }
    
}