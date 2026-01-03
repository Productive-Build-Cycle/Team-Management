using Application.Commands.AssignLeader;

using Microsoft.EntityFrameworkCore;

using TeamManagement.Application.Abstraction;
using TeamManagement.Application.Abstraction.CQRS;
using TeamManagement.Application.Commands.AddMember;
using TeamManagement.Application.Commands.AssignLeader;
using TeamManagement.Application.Commands.ChangeTeamStatus;
using TeamManagement.Application.Commands.CreateTeam;
using TeamManagement.Application.Commands.RemoveMember;
using TeamManagement.Application.Facade;
using TeamManagement.Infrastructure.Persistence.DbContext;
using TeamManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ICommandHandler<CreateTeamCommand>, CreateTeamCommandHandler>();
builder.Services.AddScoped<ICommandHandler<AddMemberCommand>, AddMemberCommandHandler>();
builder.Services.AddScoped<ICommandHandler<AssignLeaderCommand>, AssignLeaderCommandHandler>();
builder.Services.AddScoped<ICommandHandler<ChangeTeamStatusCommand>, ChangeTeamStatusCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RemoveMemberCommand>, RemoveMemberCommandHandler>();
builder.Services.AddDbContext<TeamManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ITeamFacade, TeamFacade>();


var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "akbar");
});

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
