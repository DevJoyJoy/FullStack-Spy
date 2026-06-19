
using Backend.Domain.Models;

namespace Backend.Application.Features.User.CreateAccount;

public class CreateAccountPayload
{
    public required string Name {get; set;}
    public string? Icon {get; set;}
}