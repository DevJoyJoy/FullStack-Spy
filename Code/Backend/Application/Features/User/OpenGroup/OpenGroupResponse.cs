using System.ComponentModel;
using Backend.Domain.Models;

namespace Backend.Application.Features.User.OpenGroup;

public class OpenGroupResponse
{
    public List<Lugar> Places { get; set; }
    public List<UsuarioLocDTO> Usuarios { get; set; }
    public int IdGroup { get; set; }
    public required string link { get; set; }



}