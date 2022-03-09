using desafio_cda.api.DTO;
using desafio_cda.api.Models;
using desafio_cda.api.Repositories.Context;
using desafio_cda.api.Repositories.Interfaces;

namespace desafio_cda.api.Repositories.Implementations;

public class CriminalCodeRepository : ICriminalCodeRepository
{
  private readonly AppDbContext _context;

  public CriminalCodeRepository(AppDbContext context)
  {
    _context = context;
  }
  
  public async Task<CriminalCode> Save(CreateCriminalCodeDTO entity)
  {
      var createdCriminalCode = _context.CriminalCodes.Add(new CriminalCode() {
      Name = entity.Name,
      Description = entity.Description,
      Penalty = entity.Penalty,
      PrisonTime = entity.PrisonTime,
      CreateUserId = entity.CreateUserId,
      UpdateUserId = entity.UpdateUserId,
      StatusId = entity.StatusId,
    }).Entity;

    await _context.SaveChangesAsync();

    return createdCriminalCode;
  }
}
