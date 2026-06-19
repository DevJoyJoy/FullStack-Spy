namespace Backend.Application.Features.Place.ViewCircle;

public class ViewCircleResponse
{
    public required int Id {get; set;}
    public required string Name {get; set;}
    public required int Radius {get; set;}
    public required double Latitude {get; set;}
    public required double Longitute {get; set;}
}