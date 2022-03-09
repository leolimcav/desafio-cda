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
    this._criminalCodeRepository = criminalCodeRepository;
  }
  public async Task<CreateCriminalCodeViewModel> CreateAsync(CreateCriminalCodeDTO dto)
  {
    var result = await this._criminalCodeRepository.Save(dto);

    return new CreateCriminalCodeViewModel();
  }
}
