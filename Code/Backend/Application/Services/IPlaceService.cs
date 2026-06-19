using Backend.Application;
using Backend.Application.Features.Place.CreateCircle;
using Backend.Application.Features.Place.ViewCircle;

public interface IPlaceService
{
    public Task<Result<CreateCircleResponse>> CreateCircle(CreateCirclePayload payload);
    public Task<Result<List<ViewCircleResponse>>> ViewCirclesByGroup(ViewCirclePayload payload);
    public Task<Result<ViewCircleResponse>> ViewCircleByGroup(ViewCirclePayload payload);
}