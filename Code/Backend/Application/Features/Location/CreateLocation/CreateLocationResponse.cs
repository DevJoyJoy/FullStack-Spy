namespace Backend.Application.Features.Location.CreateLocation;

public record CreateLocationResponse()
{
    public double Latitude {get; set;}
    public double Longitude {get; set;}
    public int User {get; set;}
}