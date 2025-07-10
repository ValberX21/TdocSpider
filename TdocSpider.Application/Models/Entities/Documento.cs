using System;

namespace TdocSpider.Application.Models.Entities
{
    public class Documento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public byte[] Arquivo { get; set; }
        public string NomeArquivo { get; set; }
        public string TipoArquivo { get; set; }
        public DateTime DataHoraCriacao { get; set; }
    }
}
