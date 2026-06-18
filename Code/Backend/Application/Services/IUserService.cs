namespace Backend.Application.Services;

using Backend.Application.Features.User.CreateAccount;
using Backend.Application.Features.User.DeleteAccount;
using Backend.Domain.Models;
public interface IUserService
{
    Task<Result<CreateAccountResponse>> CreateAccount(CreateAccountPayload payload);
    Task<Result<DeleteAccountResponse>> DeleteAccount(string Name);
    Task<Usuario> ViewGroupByName(string Name);
    Task<Usuario> GetUserByName(string Name);

}