using AutoMapper;
using Boticario.Github.API.Setups.ServiceCollectionExtensions;
using Boticario.Github.API.ViewModel;
using Boticario.Github.Application.Interfaces;
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
        var repositorios = await Task.Run(() => boticarioService.ListGithubReposFromDb());

        if (repositorios.Any())
        {
            var result = mapper.Map<IEnumerable<GithubRepoViewModel>>(repositorios);            

            return Results.Ok(result);
        }

        return Results.NotFound();
    }
    catch (Exception ex)
    {
        logger.LogError($"Erro ao processar a requisição - ", ex);

        return Results.BadRequest(new ErrorViewModel($"Erro ao processar a requisição", ex));
    }
});

app.MapGet("/boticario/updateListReposFromGithubAPI",
async (IBoticarioService boticarioService, ILogger<Program> logger, IMapper mapper) =>
{
    try
    {
        await Task.Run(() => boticarioService.UpdateListReposFromGithubAPI());
        return Results.Ok();                
    }
    catch (Exception ex)
    {
        logger.LogError($"Erro ao processar a requisição - ", ex);
        return Results.BadRequest(new ErrorViewModel($"Erro ao processar a requisição", ex));
    }
});

await app.RunAsync();