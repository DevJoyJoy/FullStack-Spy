using Backend.Application;
using Backend.Application.Features.GetByLinkDTO;
using Backend.Application.Features.Group.CreateGroup;
using Backend.Application.Services;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Backend.Infrastructure.Services;

public class GroupService( SpyContext ctx) : IGroupService
{
    public async Task<Result<GetBylinkDTO>> GetByLink(string link)
    {
        var group = await ctx.Grupos.FirstOrDefaultAsync(g => g.Link == link);
        if(group is null)
            return Result<GetBylinkDTO>.Fail("Link is not valid.");
        
        return Result<GetBylinkDTO>.Success(
            new GetBylinkDTO(group.Id)
        );
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

    public async Task<Result<Grupo>> GetById(int id)
    {
        Grupo? group = await ctx.Grupos.FirstOrDefaultAsync(g => g.Id == id);
        if(group is null)
            return Result<Grupo>.Fail("Group not Found");
        
        return Result<Grupo>.Success(group);
    }
}