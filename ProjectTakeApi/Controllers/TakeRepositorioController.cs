using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTakeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeRepositorioController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TakeRepositorioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("obter-repositorios-csharp")]
        public RepositoriosOrdenadosDTO ObterRepositoriosCSharp()
        {
            RepositoriosOrdenadosDTO repositoriosSort = new RepositoriosOrdenadosDTO();

            var repositorios = new GitHubController(_configuration).ObterRepositorios("takenet");

            var cincoRepositoriosAntigos = repositorios
                .Where(repo => !string.IsNullOrEmpty(repo.language?.ToString()) && repo.language.ToString() == "C#")
                .OrderByDescending(repo => repo.created_at)
                .Take(5).ToList();

            var cincoRepositorios = cincoRepositoriosAntigos
                 .OrderBy(repositorio => repositorio.created_at)
                 .Select((repo, indice) => new RepositorioDTO
                 {
                     NomeCompleto = repo.full_name,
                     Descricao = repo.description,
                     UrlAvatar = repo.owner.avatar_url,
                     UrlRepositorio = repo.html_url
                 })
                .ToList();

            //Eu criei uma versão interativa para o código abaixo mas é um desperdicio de desempenho computacional diante do escopo
            repositoriosSort.primeiro = cincoRepositorios[0];
            repositoriosSort.segundo = cincoRepositorios[1];
            repositoriosSort.terceiro = cincoRepositorios[2];
            repositoriosSort.quarto = cincoRepositorios[3];
            repositoriosSort.quinto = cincoRepositorios[4];

            return repositoriosSort;
        }
    }
}
