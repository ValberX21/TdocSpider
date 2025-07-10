
using System.Collections.Generic;
using System.Threading.Tasks;
using TdocSpider.Application.Models.Entities;
using TdocSpider.Application.Models.ViewModels;

namespace TdocSpider.Application.Services.Interfaces
{
    public interface IDocumentos
    {
        Task AddAsync(DocumentoViewModel documento);
        Task<Documento> GetByIdAsync(int id);
        Task<IEnumerable<Documento>> GetAllAsync();
        Task UpdateAsync(DocumentoAtualizaViewModel documento);
        Task<bool> DeleteAsync(int id);
    }
}
