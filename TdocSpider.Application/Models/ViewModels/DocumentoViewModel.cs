using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TdocSpider.Application.Models.ViewModels
{
    public class DocumentoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Descricao é obrigatório.")]
        [MaxLength(2000, ErrorMessage = "A descrição deve ter no máximo 2000 caracteres.")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "Adicione um arquivo.")]
        public IFormFile Arquivo { get; set; }

        public IFormFile NovoArquivo { get; set; }

        [Required(ErrorMessage = "Defina um nome para o arquivo")]
        public string NomeArquivo { get; set; }

    }
}
