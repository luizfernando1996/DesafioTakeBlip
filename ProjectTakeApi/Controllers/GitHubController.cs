using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectTakeApi.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectTakeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public GitHubController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("obter-repositorios-organizacao")] 
        public List<TemplateRepository> ObterRepositorios(string nomeOrganizacao)
        {
            var configsGitHub = _configuration.GetSection("GitHub");
            var urlBaseGitHub = configsGitHub.GetSection("UrlBase").Value;
            var pathDetalhesRepositorioGit = String.Format(configsGitHub.GetSection("Repositorio").Value, nomeOrganizacao);

            var url = String.Concat(urlBaseGitHub,pathDetalhesRepositorioGit,"?per_page=100");

            WebRequest request = WebRequest.Create(url);
            request.Headers.Add("User-Agent", "ApiIntermediaria");

            var response = request.GetResponse();
            List<TemplateRepository> repositorios;
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                repositorios = JsonSerializer.Deserialize<List<TemplateRepository>>(responseFromServer);
            }

            response.Close();  
            return repositorios;
        }
    }
}
