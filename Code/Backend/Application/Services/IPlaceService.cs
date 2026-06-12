namespace Backend.Application.Services;

using Backend.Domain.Models;
public interface IPlaceService
{
    Task<Lugar> CreateCircle(Lugar place);
    Task<Lugar> DeleteCircle(string Name);
    Task<Lugar> GetGroupByName(string Name);

}