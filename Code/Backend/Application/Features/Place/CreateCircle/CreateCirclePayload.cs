namespace Backend.Application.Features.Place.CreateCircle;

public class CreateCirclePayload
{
    public int UserId {get; set;}
    public int GroupId {get; set;}
    public int PlaceId {get;set;}
    public required string Name {get; set;}
    public int Radiues {get; set;}

}