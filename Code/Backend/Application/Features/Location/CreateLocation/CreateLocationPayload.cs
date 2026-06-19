namespace Backend.Application.Features.Location.CreateLocation;

public record CreateLocationPayload()
{
    public double Latitude {get; set;}
    public double Longitude {get; set;}
    public int UserId {get; set;}

}