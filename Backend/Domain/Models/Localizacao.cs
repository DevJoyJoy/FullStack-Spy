public class Localizacao : BaseModel
{
    //================PROPERTIES================
    public required double Latitude {get;set;}
    public required double Longitude {get;set;}
    public required DateTime Data {get;set;}


    //================MY-RELATIONS================
    public required Usuario Usuario {get;set;}
    public required int UsuarioId {get;set;}
}