using desafio_cda.api.DTO;
using desafio_cda.api.ViewModels;

namespace desafio_cda.api.Services.Interfaces;

public interface ICriminalCodeService
{
  Task<CreateCriminalCodeViewModel> CreateAsync(CreateCriminalCodeDTO dto);
}
