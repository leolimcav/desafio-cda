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
    _criminalCodeService = criminalCodeService;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<CriminalCodeViewModel>>> GetAll([FromQuery] string? orderBy, [FromQuery] FilterCriminalCode filters, [FromQuery] PaginationFilter paginationFilter)
  {
    return Ok(await _criminalCodeService.GetAllAsync(orderBy, filters, paginationFilter));
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<CriminalCodeViewModel>> GetById([FromRoute] long id)
  {
    var criminalCode = await _criminalCodeService.GetByIdAsync(id);

    return criminalCode is null ? NotFound("Criminal Code Not Found!") : Ok(criminalCode);
  }
  
  [HttpPost]
  public async Task<ActionResult<CriminalCodeViewModel>> Create([FromBody] CreateCriminalCodeDTO dto)
  {
    var createdCriminalCode = await _criminalCodeService.CreateAsync(dto);

    return createdCriminalCode is null ? BadRequest("Criminal Code with this name already exists!") : Created("", createdCriminalCode);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<CriminalCodeViewModel>> Update([FromRoute] long id,
    [FromBody] UpdateCriminalCodeDTO dto)
  {
    var updatedCriminalCode = await _criminalCodeService.UpdateAsync(id, dto);

    return updatedCriminalCode is null ? NotFound("Criminal Code Not Found!") : Ok(updatedCriminalCode);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<CriminalCodeViewModel>> Remove([FromRoute] long id)
  {
    var deletedCriminalCode = await _criminalCodeService.RemoveAsync(id);
    
    return deletedCriminalCode is null ? NotFound("Criminal Code Not Found!") : Ok(deletedCriminalCode);
  }
}
