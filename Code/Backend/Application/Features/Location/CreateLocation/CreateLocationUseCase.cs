using Backend.Application.Services;

namespace Backend.Application.Features.Location.CreateLocation;

public class CreateLocationUseCase(ILocationService service)
{
    public Task<Result<CreateLocationResponse>> Do(CreateLocationPayload payload)
    {
        return service.CreateLocation(payload);
    }
}