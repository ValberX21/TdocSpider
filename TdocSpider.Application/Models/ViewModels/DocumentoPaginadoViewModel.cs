using System.Collections.Generic;
using TdocSpider.Application.Models.Entities;

namespace TdocSpider.Application.Models.ViewModels
{
    public class DocumentoPaginadoViewModel
    {
        public IEnumerable<Documento> Documentos { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public string FiltroTitulo { get; set; }
        public string OrdenarPor { get; set; }
        public string DirecaoOrdenacao { get; set; }
    }
}
