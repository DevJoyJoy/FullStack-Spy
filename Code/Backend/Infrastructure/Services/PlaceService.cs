using Backend.Application;
using Backend.Application.Features.Place.CreateCircle;
using Backend.Application.Features.Place.ViewCircle;
using Backend.Application.Services;
using Backend.Domain.Models;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class PlaceService(SpyContext ctx, IGroupService groupService) : IPlaceService
{
    public async Task<Result<CreateCircleResponse>> CreateCircle(CreateCirclePayload payload)
    {
        var place = ctx.Lugares.FirstOrDefaultAsync(l => l.Id == payload.PlaceId);
        if(place is not null)
            return Result<CreateCircleResponse>.Fail("This circle already exists!.");
        
        Grupo grupo = (await groupService.GetById(payload.GroupId)).data;

        var newPlace = new Lugar()
        {
            Nome = payload.Name,
            Raio = payload.Radiues,
            Grupo = grupo,
            GrupoId = grupo.Id,
        };

        return Result<CreateCircleResponse>.Success( new CreateCircleResponse()
        {
            Name = newPlace.Nome,
            Createdby = 
        });
    }

    public Task<Result<ViewCircleResponse>> ViewCircleByGroup(ViewCirclePayload payload)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<ViewCircleResponse>>> ViewCirclesByGroup(ViewCirclePayload payload)
    {
        throw new NotImplementedException();
    }
}