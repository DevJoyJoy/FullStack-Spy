using System.ComponentModel.DataAnnotations;

namespace Backend.Application.Features.Group.CreateGroup;

public class CreateGroupPayload
{
    [Required]
    public string Nome {get; set;}

}