namespace Backend.Domain.Models;

public class Usuario : BaseModel
{
    //================PROPERTIES================
    public required string Nome {get;set;}
    public string Icon {get;set;} = " :(: ";


    //================RELATIONS================
    public ICollection<Grupo> Grupos {get;set;} = [];
    public ICollection<Localizacao> Localizacoes {get;set;} = [];
    public ICollection<Notificacao> NotificacoesEnviadas  {get;set;} = [];
    public ICollection<Notificacao> NotificacoesRecebidas  {get;set;} = [];
}