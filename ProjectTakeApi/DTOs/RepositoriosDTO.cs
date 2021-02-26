using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTakeApi
{
    public class RepositorioDTO
    {
        public string NomeCompleto { get; set; }
        public string Descricao { get; set; }
        public string UrlAvatar { get; set; }
        public string UrlRepositorio { get; set; }

    }

    public class RepositoriosOrdenadosDTO
    {
        public RepositorioDTO primeiro { get; set; }
        public RepositorioDTO segundo { get; set; }
        public RepositorioDTO terceiro { get; set; }
        public RepositorioDTO quarto { get; set; }
        public RepositorioDTO quinto { get; set; }

    }
}
