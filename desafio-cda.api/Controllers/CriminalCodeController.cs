using desafio_cda.api.DTO;
using desafio_cda.api.Services.Interfaces;
using desafio_cda.api.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace desafio_cda.api.Controllers;

[Route("/criminalcodes")]
public class CriminalCodeController : BaseController
{
  private readonly ICriminalCodeService _criminalCodeService;
  
  public CriminalCodeController(ICriminalCodeService criminalCodeService)
  {
    this._criminalCodeService = criminalCodeService;
  }

  [HttpPost]
  [Route("/")]
  public async Task<CreateCriminalCodeViewModel> Create([FromBody] CreateCriminalCodeDTO dto)
  {
    return await _criminalCodeService.CreateAsync(dto);
  }
}
