using System.Text.RegularExpressions;
using Backend.Application;
using Backend.Application.Features.GetByLinkDTO;
using Backend.Application.Features.Group.CreateGroup;
using Backend.Application.Features.User.CreateAccount;
using Backend.Application.Services;
using Backend.Domain.Models;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Services;

public class GroupService( SpyContext ctx) : IGroupService
{
    public Task<Result<GetBylinkDTO>> GetByLink(string link)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<CreateGroupResponse>> CreateGroup(CreateGroupPayload payload)
    {
        var group = await ctx.Grupos.AnyAsync(n => n.Nome == payload.Nome);
        if(group) 
            return Result<CreateGroupResponse>.Fail("This group already exists!");

        var newGroup = new Grupo(){
            Nome = payload.Nome
        };

        ctx.Grupos.Add(newGroup);
        await ctx.SaveChangesAsync();

        return Result<CreateGroupResponse>.Success(new CreateGroupResponse()
        {
            Nome = newGroup.Nome
        });
    }
}