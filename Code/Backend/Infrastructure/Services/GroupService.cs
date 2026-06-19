using Backend.Application;
using Backend.Application.Features.GetByLinkDTO;
using Backend.Application.Features.Group.CreateGroup;
using Backend.Application.Features.Group.DeleteGroup;
using Backend.Application.Features.Group.JoinGroup;
using Backend.Application.Services;
using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Backend.Infrastructure.Services;

public class GroupService( SpyContext ctx, IUserService userService) : IGroupService
{
    public async Task<Result<string>> AddMember(JoinGroupPayload payload)
    {
        Grupo? group = await ctx.Grupos.FirstOrDefaultAsync(g => g.Link == payload.Link);
        if(group is null)
            return Result<string>.Fail("Link is not valid.");
        
        Usuario? user = await ctx.Usuarios.FirstOrDefaultAsync(u => u.Id == payload.UserId);
        if(user is null)
            return Result<string>.Fail("User not Found");

        group.Usuarios.Add(user);

        return Result<string>.Success($"{user.Nome} was added to the group");
    }

    public async Task<Result<CreateGroupResponse>> CreateGroup(CreateGroupPayload payload)
    {
        var group = await ctx.Grupos.AnyAsync(n => n.Nome == payload.Nome);
        if(group) 
            return Result<CreateGroupResponse>.Fail("This group already exists!");

        var newGroup = new Grupo(){
            Nome = payload.Nome
        };

        Usuario user = (await userService.GetUserById(payload.UserId)).data;

        newGroup.Usuarios.Add(user);
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

    public async Task<Result<string>> DeleteGroup(DeleteGroupPayload payload)
    {
        Grupo? group = await ctx.Grupos.FirstOrDefaultAsync(g => g.Id == payload.GroupId);
        if(group is null)
            return Result<string>.Fail("Group not Found");
        
        ctx.Grupos.Remove(group);
        await ctx.SaveChangesAsync();

        return Result<string>.Success("Group deleted");
    }
}