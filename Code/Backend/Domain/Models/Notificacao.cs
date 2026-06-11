public class Notificacao : BaseModel
{
    //================PROPERTIES================
    public required int Id {get;set;}
    public required string Mensagem {get;set;}

    //================MY-RELATIONS================
    public required int IdRemetente {get;set;}
    public required Usuario Remetente {get;set;}
    
    public required int IdDestinatario {get;set;}
    public required Usuario Destinatario {get;set;}
}