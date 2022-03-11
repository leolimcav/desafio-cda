using desafio_cda.api.DTO;
using desafio_cda.api.Models;

namespace desafio_cda.api.Repositories.Interfaces;

public interface ICriminalCodeRepository
{
  Task<IEnumerable<CriminalCode>> GetAllAsync(string? orderBy, FilterCriminalCode filters, PaginationFilter paginationFilter);
  Task<CriminalCode?> GetByIdAsync(long id);
  Task<CriminalCode?> SaveAsync(CreateCriminalCodeDTO entity);
  Task<CriminalCode?> UpdateAsync(long id, UpdateCriminalCodeDTO entity);
  Task<CriminalCode?> RemoveAsync(long id);
}
