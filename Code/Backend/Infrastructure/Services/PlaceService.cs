using Backend.Application;
using Backend.Application.Features.Place.CreateCircle;
using Backend.Application.Features.Place.ViewCircle;
using Backend.Application.Services;
using Backend.Domain.Models;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class PlaceService(SpyContext ctx, IGroupService groupService, IUserService userService) : IPlaceService
{
    public async Task<Result<CreateCircleResponse>> CreateCircle(CreateCirclePayload payload)
    {
        var place = ctx.Lugares.FirstOrDefaultAsync(l => l.Id == payload.PlaceId);
        if(place is not null)
            return Result<CreateCircleResponse>.Fail("This circle already exists!.");
        
        Grupo grupo = (await groupService.GetById(payload.GroupId)).data;
        Usuario user = (await userService.GetUserById(payload.UserId)).data;

        var newPlace = new Lugar()
        {
            Nome = payload.Name,
            Raio = payload.Radiues,
            Grupo = grupo,
            GrupoId = grupo.Id,
            Latitude = payload.Latitude,
            Longitude = payload.Longitude
        };

        return Result<CreateCircleResponse>.Success( new CreateCircleResponse()
        {
            Name = newPlace.Nome,
            Createdby = user.Nome
        });
    }

    public async Task<Result<ViewCircleResponse>> ViewCircleByIdAndByGroup(ViewCirclePayload payload)
    {
        var group = await ctx.Grupos.FirstOrDefaultAsync(g => g.Id == payload.GroupId);
        if(group is null)
            return Result<ViewCircleResponse>.Fail("Group not Found");

        Lugar? place = group.Lugares.FirstOrDefault(l => l.Id == payload.PlaceId);
        if( place is null)
            return Result<ViewCircleResponse>.Fail("Circle not Found");

        return Result<ViewCircleResponse>.Success(new ViewCircleResponse()
        {
            Id = place.Id,
            Name = place.Nome,
            Radius = place.Raio,
            Latitude = place.Latitude,
            Longitute = place.Longitude
        });
    }

    public async Task<Result<List<ViewCircleResponse>>> ViewCirclesByGroup(ViewCirclePayload payload)
    {
        var group = await ctx.Grupos
            .Include( g => g.Lugares)
            .FirstOrDefaultAsync(l => l.Id == payload.GroupId);
        if(group is null)
            return Result<List<ViewCircleResponse>>.Fail("Group not Found");
        
        List<Lugar> places = group.Lugares.ToList();

        List<ViewCircleResponse> circles = places.Select(
            p =>
                new ViewCircleResponse
                {
                    Id = p.Id,
                    Latitude = p.Latitude,
                    Longitute = p.Longitude,
                    Name = p.Nome,
                    Radius = p.Raio
                }

        ).ToList();

        return Result<List<ViewCircleResponse>>.Success(circles);
    }
}