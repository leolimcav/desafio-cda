using desafio_cda.api.DTO;
using desafio_cda.api.ViewModels;

namespace desafio_cda.api.Services.Interfaces;

public interface IStatusService
{
  Task<StatusViewModel> CreateAsync(CreateStatusDTO dto);
}
