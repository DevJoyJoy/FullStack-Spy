using System.Text.RegularExpressions;
using Backend.Application;
using Backend.Application.Features.Group.CreateGroup;
using Backend.Application.Features.User.CreateAccount;
using Backend.Application.Services;
using Backend.Domain.Models;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Services;

public class GroupService( SpyContext ctx) : IGroupService

{
    public async Task<Result<CreateGroupResponse>> CreateGroup(CreateGroupPayload payload)
    {
       var group = await ctx.Grupos.AnyAsync(n => n.Nome == payload.Nome);
        if(group) 
            return Result<CreateGroupResponse>.Fail("This group already exists!");
        
        group = new Group()

        ctx.Grupos.Add(group);
        await ctx.SaveChangesAsync();
    }

    public Task<Grupo> GetByLink(string link)
    {
        throw new NotImplementedException();
    }

}