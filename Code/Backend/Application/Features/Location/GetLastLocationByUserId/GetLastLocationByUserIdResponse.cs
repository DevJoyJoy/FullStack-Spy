namespace Backend.Application.Features.Location.GetLastLocationByUserId;

public record GetLastLocationByUserIdResponse()
{
    public double Latitude {get; set;}
    public double Longitude {get; set;}
    public int UserId {get; set;}
}