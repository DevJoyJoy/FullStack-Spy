using Backend.Application.Features.Location.CreateLocation;
using Backend.Application.Features.Location.GetLastLocationByUserId;

namespace Backend.Application.Services;

public interface ILocationService {
    public Task<Result<CreateLocationResponse>> CreateLocation(CreateLocationPayload payload);
    public Task<Result<GetLastLocationByUserIdResponse>> GetLastLocationByUserId(int user);
}
