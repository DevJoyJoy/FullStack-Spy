using Backend.Application.Features.User.D;
using Backend.Application.Services;
using Backend.Domain.Models;
using Microsoft.VisualBasic;

namespace Backend.Application.Features.User.OpenGroup;

public class OpenGroupUseCase
(
    IGroupService groupService

)
{
    public async Task<Result<OpenGroupResponse>> Do( OpenGroupPayload payload)
    {
        Result<Grupo> grupo = await groupService.GetById(payload.IdGroup);
        
        
        if(!grupo.IsSuccess)
            return Result<OpenGroupResponse>.Fail("Fail finding Group Id");

        if(grupo.data.Link is null)
            return Result<OpenGroupResponse>.Fail("Fail finding Group Link");


        return Result<OpenGroupResponse>.Success(new OpenGroupResponse()
        {
            IdGroup = grupo.data.Id,
            link = grupo.data.Link,
            Places = grupo.data.Lugares.ToList() ,
            Usuarios = grupo.data.Usuarios
                .Select(u => new UsuarioLocDTO()
                {
                    idUsuario = u.Id,
                    nome = u.Nome,
                    icone = u.Icon,
                    latidude = 
                })
                .ToList()
        });

    }
}