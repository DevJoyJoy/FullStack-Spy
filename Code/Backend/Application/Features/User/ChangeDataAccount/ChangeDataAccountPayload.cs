using Backend.Application.Features.User.CreateAccount;
using Backend.Application.Services;
using Backend.Domain.Models;

namespace Backend.Application.Features.User.ChangeDataAccount;

public class ChangeDataAccountPayload()
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public string? Icon {get; set;}
}
 
    
