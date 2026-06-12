namespace Backend.Domain.Models;

public class Lugar : BaseModel
{
    //================PROPERTIES================
    public required string Nome {get;set;}
    public required int Raio {get;set;}


    //================MY-RELATIONS================
    public required Grupo Grupo {get;set;}
    public required int GrupoId {get;set;}
}