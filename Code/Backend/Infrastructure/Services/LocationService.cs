using Backend.Application;
using Backend.Application.Features.Location;
using Backend.Application.Features.Location.CreateLocation;
using Backend.Application.Features.Location.GetLastLocationByUserId;
using Backend.Application.Services;
using Backend.Infrastructure;
using Backend.Infrastructure.Services;

public class LocationServices(SpyContext ctx) : ILocationService
{
    public async Task<Result<CreateLocationResponse>> CreateLocation(CreateLocationPayload payload)
    {
        var user = ctx.Usuarios.FirstOrDefault(u => u.Id == payload.UserId);

        if(user is null) 
            return Result<CreateLocationResponse>.Fail("Couldn't find user!");

        Localizacao local = new Localizacao
        {
            Latitude = payload.Latitude,
            Longitude = payload.Longitude,
            UsuarioId = payload.UserId,
            Usuario = user,
            Data = new DateTime()
        };

        ctx.Localizacoes.Add(local);
        await ctx.SaveChangesAsync();

        return Result<CreateLocationResponse>.Success(new CreateLocationResponse()
        {
           Latitude = local.Latitude,
           Longitude = local.Longitude,
           User = local.UsuarioId

        });
    }

    public async Task<Result<GetLastLocationByUserIdResponse>> GetLastLocationByUserId(int UserId)
    {
        var local = ctx.Localizacoes
            .Where(l => l.UsuarioId == UserId)
            .OrderByDescending(l => l.Data)
            .FirstOrDefault();

        if (local is null)
            return Result<GetLastLocationByUserIdResponse>.Fail("Couldn't find location");
        
        return Result<GetLastLocationByUserIdResponse>.Success(new GetLastLocationByUserIdResponse()
        {
           Latitude = local.Latitude,
           Longitude = local.Longitude,
           UserId = local.UsuarioId 
        });
    }
}