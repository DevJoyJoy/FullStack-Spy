using Microsoft.Extensions.DependencyInjection;
using Backend.Application.Features.Group.CreateGroup;
using Backend.Application.Features.Group.DeleteGroup;
using Backend.Application.Features.Group.JoinGroup;
using Backend.Application.Features.Group.ShareGroup;
using Backend.Application.Features.User.ChangeDataAccount;
using Backend.Application.Features.User.CreateAccount;
using Backend.Application.Features.User.DeleteAccount;
using Backend.Application.Features.User.OpenGroup;
using Backend.Application.Features.User.ReactLocation;
using Backend.Application.Features.User.ViewGroups;
using Backend.Application.Features.Place.ChangeLocation;
using Backend.Application.Features.Place.ChangeName;
using Backend.Application.Features.Place.ChangeRadius;
using Backend.Application.Features.Place.CreateCircle;
using Backend.Application.Features.Place.DeleteCircle;
using Backend.Application.Features.Place.ViewCircle;

public static class UseCaseConfiguration
{
    public static void AddUseCases(this IServiceCollection services)
    {
        // Group
        services.AddTransient<ChangeGroupNameUseCase>();
        services.AddTransient<CreateGroupUseCase>();
        services.AddTransient<DeleteGroupUseCase>();
        services.AddTransient<JoinGroupUseCase>();
        services.AddTransient<ShareGroupUseCase>();

        //Location
        services.AddTransient<GetDataUseCase>();
        services.AddTransient<GetLatitudeUseCase>();
        services.AddTransient<GetLongitudeUseCase>();

        //Place
        services.AddTransient<ChangeLocationUseCase>();
        services.AddTransient<ChangeNameUseCase>();
        services.AddTransient<ChangeRadiusUseCase>();
        services.AddTransient<CreateCircleUseCase>();
        services.AddTransient<DeleteCircleUseCase>();
        services.AddTransient<ViewCircleUseCase>();

        //User
        services.AddTransient<ChangeDataAccountUseCase>();
        services.AddTransient<CreateAccountUseCase>();
        services.AddTransient<DeleteAccountUseCase>();
        services.AddTransient<OpenGroupUseCase>();
        services.AddTransient<ReactLocationUseCase>();
        services.AddTransient<ViewGroupUseCase>();
    }
}