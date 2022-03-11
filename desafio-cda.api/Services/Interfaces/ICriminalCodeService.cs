using desafio_cda.api.DTO;
using desafio_cda.api.ViewModels;

namespace desafio_cda.api.Services.Interfaces;

public interface ICriminalCodeService
{
  Task<IEnumerable<CriminalCodeViewModel>> GetAllAsync(string? orderBy, FilterCriminalCode filters, PaginationFilter paginationFilter);
  Task<CriminalCodeViewModel?> GetByIdAsync(long id);
  Task<CriminalCodeViewModel?> CreateAsync(CreateCriminalCodeDTO dto);
  Task<CriminalCodeViewModel?> UpdateAsync(long id, UpdateCriminalCodeDTO dto);
  Task<CriminalCodeViewModel?> RemoveAsync(long id);
}
