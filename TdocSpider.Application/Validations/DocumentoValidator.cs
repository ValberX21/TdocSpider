using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using TdocSpider.Application.Data;

namespace TdocSpider.Application.Validations
{
    public class DocumentoValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public DocumentoValidator(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public bool TituloJaExiste(string titulo)
        {
            var tituloExistente = _dbContext.Documento.FirstOrDefault(d => d.Titulo == titulo);

            if (tituloExistente != null)
                return true;

            return false;
        }

        public bool TipoArquivoPermitido(IFormFile fileName)
        {
            var extension = Path.GetExtension(fileName.FileName).ToLower();

            if (extension == ".exe" || extension == ".zip" || extension == ".bat")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
