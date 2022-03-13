using desafio_cda.api.DTO;
using desafio_cda.api.Services.Interfaces;
using desafio_cda.api.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace desafio_cda.api.Controllers;

[Route("/status")]
public class StatusController : BaseController
{
  private readonly IStatusService _statusService;

  public StatusController(IStatusService statusService)
  {
    _statusService = statusService;
  }
  public async Task<ActionResult<StatusViewModel>> Create([FromBody] CreateStatusDTO dto)
  {
    var createdStatus = await _statusService.CreateAsync(dto);

    return Created("", createdStatus);
  }
}
