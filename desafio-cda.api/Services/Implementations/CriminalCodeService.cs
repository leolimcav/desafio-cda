using desafio_cda.api.DTO;
using desafio_cda.api.Repositories.Interfaces;
using desafio_cda.api.Services.Interfaces;
using desafio_cda.api.ViewModels;

namespace desafio_cda.api.Services.Implementations;

public class CriminalCodeService : ICriminalCodeService
{
  private readonly ICriminalCodeRepository _criminalCodeRepository;
  
  public CriminalCodeService(ICriminalCodeRepository criminalCodeRepository)
  {
    _criminalCodeRepository = criminalCodeRepository;
  }

  public async Task<IEnumerable<CriminalCodeViewModel>> GetAllAsync(string? orderBy, FilterCriminalCode filters, PaginationFilter paginationFilter)
  {
    var criminalCodes = await _criminalCodeRepository.GetAllAsync(orderBy, filters, paginationFilter);

    var criminalCodeViewModelEnumerable = criminalCodes.Select(CriminalCodeViewModel.ModelToViewModel); 
    return criminalCodeViewModelEnumerable;
  }

  public async Task<CriminalCodeViewModel?> GetByIdAsync(long id)
  {
    var criminalCode = await _criminalCodeRepository.GetByIdAsync(id);
    
    return criminalCode is null ?  null : CriminalCodeViewModel.ModelToViewModel(criminalCode);
  }

  public async Task<CriminalCodeViewModel?> CreateAsync(CreateCriminalCodeDTO dto)
  {
    var createdCriminalCode = await this._criminalCodeRepository.SaveAsync(dto);

    return createdCriminalCode is null ? null : CriminalCodeViewModel.ModelToViewModel(createdCriminalCode);
  }

  public async Task<CriminalCodeViewModel?> UpdateAsync(long id, UpdateCriminalCodeDTO dto)
  {
    var updatedCriminalCode = await _criminalCodeRepository.UpdateAsync(id, dto);
    
    return updatedCriminalCode is null ? null : CriminalCodeViewModel.ModelToViewModel(updatedCriminalCode);
  }

  public async Task<CriminalCodeViewModel?> RemoveAsync(long id)
  {
    var deletedCriminalCode = await _criminalCodeRepository.RemoveAsync(id);
    
    return deletedCriminalCode is null ? null : CriminalCodeViewModel.ModelToViewModel(deletedCriminalCode);
  }
}
