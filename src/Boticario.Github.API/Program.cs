using AutoMapper;
using Boticario.Github.API.Setups.ServiceCollectionExtensions;
using Boticario.Github.API.ViewModel;
using Boticario.Github.Application.Interfaces;
using Boticario.Github.Domain.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

var app = builder.Build();
var environment = app.Environment;

app.UseRouting()   
   .UseExceptionHandling(environment);

app.MapGet("/boticario/getRepositorios", 
async (IBoticarioService boticarioService, ILogger<Program> logger, IMapper mapper) =>
{
    try
    {                
        var repositorios = await Task.Run(() => boticarioService.ListarTodosOsRepositorios());

        if (repositorios.Any())
        {
            var result = mapper.Map<IEnumerable<GithubLanguageRepoViewModel>>(repositorios);

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

app.MapGet("/boticario/listReposFromGithubAPI",
async (IGithubService githubService, ILogger<Program> logger, IMapper mapper) =>
{
    try
    {
        var response = await Task.Run(() => githubService.ListReposFromGithubAPI());

        if (response.Any())
        {
            var result = mapper.Map<IEnumerable<GithubLanguageRepoViewModel>>(response);
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

await app.RunAsync();