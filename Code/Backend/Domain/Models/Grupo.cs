public class Grupo : BaseModel
{
    //================PROPERTIES================
    public required string Nome {get;set;}


    //================RELATIONS================
    public required ICollection<Usuario> Usuarios {get;set;} = [];
    public required ICollection<Lugar> Lugares {get;set;} = [];
}