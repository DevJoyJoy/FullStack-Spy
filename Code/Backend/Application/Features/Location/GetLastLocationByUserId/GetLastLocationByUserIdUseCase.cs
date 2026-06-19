using Backend.Application.Services;

namespace Backend.Application.Features.Location.GetLastLocationByUserId;

public class GetLastLocationByUserIdUseCase(ILocationService service)
{
    public Task<Result<GetLastLocationByUserIdResponse>> Do(int user)
    {
        return service.GetLastLocationByUserId(user);
    }
}