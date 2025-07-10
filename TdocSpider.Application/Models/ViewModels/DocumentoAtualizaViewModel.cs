using Microsoft.AspNetCore.Http;

namespace TdocSpider.Application.Models.ViewModels
{
    public class DocumentoAtualizaViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public IFormFile Arquivo { get; set; }

        public string NomeArquivo { get; set; }
    }
}
