using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TdocSpider.Application.Models.Entities;
using TdocSpider.Application.Models.ViewModels;
using TdocSpider.Application.Services.Interfaces;
using TdocSpider.Repository.Interfaces;

namespace TdocSpider.Application.Services
{
    public class DocumentoService : IDocumentos
    {
        private readonly IDocumentoRepository _documentoRepository;

        public DocumentoService(IDocumentoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository;
        }

        public Task AddAsync(DocumentoViewModel documento)
        {
            using var memoryStream = new MemoryStream();
            documento.Arquivo.CopyToAsync(memoryStream);

            string extensaoArquivo = Path.GetExtension(documento.Arquivo.FileName);

            Documento doc = new Documento
            {
                Id = documento.Id,
                Titulo = documento.Titulo,
                Descricao = documento.Descricao,
                NomeArquivo = documento.NomeArquivo,
                Arquivo = memoryStream.ToArray(),
                TipoArquivo = extensaoArquivo,
                DataHoraCriacao = DateTime.UtcNow
            };

            return _documentoRepository.AddAsync(doc);
        }

        public Task<IEnumerable<Documento>> GetAllAsync()
        {
            return _documentoRepository.GetAllAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _documentoRepository.DeleteAsync(id);
        }

        public Task<Documento> GetByIdAsync(int id)
        {
            return _documentoRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(DocumentoAtualizaViewModel documento)
        {
            var doc = await _documentoRepository.GetByIdAsync(documento.Id);
            if (doc == null) throw new Exception("Documento não encontrado.");

            doc.Titulo = documento.Titulo;
            doc.Descricao = documento.Descricao;
            doc.NomeArquivo = documento.NomeArquivo;

            if (documento.Arquivo != null && documento.Arquivo.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await documento.Arquivo.CopyToAsync(memoryStream);

                doc.Arquivo = memoryStream.ToArray();
                doc.NomeArquivo = documento.Arquivo.FileName;
                doc.TipoArquivo = Path.GetExtension(documento.Arquivo.FileName);
                doc.DataHoraCriacao = DateTime.UtcNow;
            }

            await _documentoRepository.UpdateAsync(doc);
        }
    }
}
