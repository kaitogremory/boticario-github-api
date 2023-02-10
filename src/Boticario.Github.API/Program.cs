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
        logger.LogError($"Erro ao processar a requisi��o - ", ex);

        return Results.BadRequest(new ErrorViewModel($"Erro ao processar a requisi��o", ex));
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
        logger.LogError($"Erro ao processar a requisi��o - ", ex);
        return Results.BadRequest(new ErrorViewModel($"Erro ao processar a requisi��o", ex));
    }
});

await app.RunAsync();