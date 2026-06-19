namespace Backend.Domain.Models;
public class Grupo : BaseModel
{
    //================PROPERTIES================
    public required string Nome {get;set;}

    public string? Link {get; set;}

    //================RELATIONS================
    public ICollection<Usuario> Usuarios {get;set;} = [];
    public ICollection<Lugar> Lugares {get;set;} = [];
}