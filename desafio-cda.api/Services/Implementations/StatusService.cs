using desafio_cda.api.DTO;
using desafio_cda.api.Repositories.Interfaces;
using desafio_cda.api.Services.Interfaces;
using desafio_cda.api.ViewModels;

namespace desafio_cda.api.Services.Implementations;

public class StatusService : IStatusService
{
  private readonly IStatusRepository _statusRepository;

  public StatusService(IStatusRepository statusRepository)
  {
    _statusRepository = statusRepository;
  }
  public async Task<StatusViewModel> CreateAsync(CreateStatusDTO dto)
  {
    var createdStatus = await _statusRepository.CreateAsync(dto);

    return StatusViewModel.ModelToViewModel(createdStatus);
  }
}
