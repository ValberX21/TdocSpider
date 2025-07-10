using System.Collections.Generic;
using System.Threading.Tasks;
using TdocSpider.Application.Models.Entities;

namespace TdocSpider.Repository.Interfaces
{
    public interface IDocumentoRepository
    {

        Task AddAsync(Documento documento);

        Task<Documento> GetByIdAsync(int id);
        Task<IEnumerable<Documento>> GetAllAsync();
        
        Task UpdateAsync(Documento documento);
        Task<bool> DeleteAsync(int id);
    }
}
