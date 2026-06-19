using Backend.Application.Services;

namespace Backend.Application.Features.User.DeleteAccount;

public class DeleteAccountUseCase(
    IUserService userService   
)
{
    public async Task<Result<string>> Do ( string Name)
    {
        return await userService.DeleteAccount(Name);
    }  
}
