using AutoMapper;
using Boticario.Github.API.Setups.ServiceCollectionExtensions;
using Boticario.Github.API.ViewModel;
using Boticario.Github.Application.Interfaces;
using MongoDB.Driver.Linq;
using System.Diagnostics.CodeAnalysis;

[assembly: ExcludeFromCodeCoverage]

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

var app = builder.Build();
var environment = app.Environment;

app.UseCors("devCorsPolicy");

app.UseRouting()   
   .UseExceptionHandling(environment);

app.MapGet("/boticario/getRepositoriesList", 
async (IBoticarioService boticarioService, ILogger<Program> logger, IMapper mapper) =>
{
    try
    {                
        var repositories = await Task.Run(() => boticarioService.ListGithubReposFromDb());

        if (repositories.Any())                    
            return Results.Ok(mapper.Map<IEnumerable<GithubRepoViewModel>>(repositories));            
        else
            return Results.NoContent();
    }
    catch (Exception ex)
    {
        logger.LogError($"Error processing the request - ", ex);
        return Results.BadRequest(new ErrorViewModel($"Error processing the request", ex));
    }
});

app.MapGet("/boticario/updateListReposFromGithubAPI",
async (IBoticarioService boticarioService, ILogger<Program> logger, IMapper mapper) =>
{
    try
    {
        await Task.Run(() => boticarioService.UpdateListReposFromGithubAPI());
        return Results.Ok(true);                
    }
    catch (Exception ex)
    {
        logger.LogError($"Error processing the request - ", ex);
        return Results.BadRequest(new ErrorViewModel($"Error processing the request", ex));
    }
});

app.MapGet("/boticario/getRepoDetailByName/{name}",
async (string name, IBoticarioService boticarioService, ILogger<Program> logger, IMapper mapper) =>
{
    try
    {
        var repository = await Task.Run(() => boticarioService.GetRepoDetailByName(name));

        if(repository == null)        
            return Results.NoContent();
        
        else if (!repository.IsValid())
            return Results.BadRequest(new ErrorViewModel("Invalid Data", repository.Notes.Errors));                

        return Results.Ok(repository);
    }
    catch (Exception ex)
    {
        logger.LogError($"Error processing the request - ", ex);
        return Results.BadRequest(new ErrorViewModel($"Error processing the request", ex));
    }
});

app.MapDelete("/boticario/clearRepositoriesFromBase",
async (IBoticarioService boticarioService, ILogger<Program> logger, IMapper mapper) =>
{
    try
    {
        await Task.Run(() => boticarioService.ClearCollection());
        return Results.Ok(true);
    }
    catch (Exception ex)
    {
        logger.LogError($"Error processing the request - ", ex);
        return Results.BadRequest(new ErrorViewModel($"Error processing the request", ex));
    }
});

await app.RunAsync();