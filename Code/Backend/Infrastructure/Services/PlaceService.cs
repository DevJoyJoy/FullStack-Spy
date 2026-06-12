using Backend.Application.Services;
using Backend.Domain.Models;

namespace Backend.Infrastructure.Services;

public class PlaceService : IPlaceService
{
    public Task<Lugar> CreateCircle(Lugar place)
    {
        throw new NotImplementedException();
    }

    public Task<Lugar> DeleteCircle(string Name)
    {
        throw new NotImplementedException();
    }

    public Task<Lugar> GetGroupByName(string Name)
    {
        throw new NotImplementedException();
    }
}