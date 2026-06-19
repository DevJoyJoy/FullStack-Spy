namespace Backend.Application.Services;

using Backend.Application.Features.User.CreateAccount;
using Backend.Application.Features.User.DeleteAccount;
using Backend.Domain.Models;
public interface IUserService
{
    Task<Result<CreateAccountResponse>> CreateAccount(CreateAccountPayload payload);
    Task<Result<string>> DeleteAccount(string Name);
    Task<Result<CreateAccountResponse>> GetUserByName(string Name);
    Task<Result<Usuario>> GetUserById(int Id);
    Task<Result<List<Grupo>>>  ViewGroupByName(string Name);

}