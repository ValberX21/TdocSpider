using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TdocSpider.Application.Data;
using TdocSpider.Application.Models.Entities;
using TdocSpider.Repository.Interfaces;

namespace TdocSpider.Application.Repository
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DocumentoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Documento documento)
        {
            _dbContext.Documento.Add(documento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Documento> GetByIdAsync(int id)
        {
            return await _dbContext.Documento.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var documento = await _dbContext.Documento.FindAsync(id);

            if (documento == null)
                return false;

            _dbContext.Documento.Remove(documento);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Documento>> GetAllAsync()
        {
            return await _dbContext.Documento.ToListAsync();
        }

        public async Task UpdateAsync(Documento documento)
        {
            _dbContext.Documento.Update(documento);
            await _dbContext.SaveChangesAsync();
        }
    }
}
