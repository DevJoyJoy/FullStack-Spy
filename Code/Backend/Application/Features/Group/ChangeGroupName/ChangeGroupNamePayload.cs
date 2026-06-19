using Microsoft.VisualBasic;

namespace Backend.Application.Features.Group.CreateGroup;
public class ChangeGroupNamePayload
{
    public int GroupID {get; set;}
    public string Name {get; set;}
}