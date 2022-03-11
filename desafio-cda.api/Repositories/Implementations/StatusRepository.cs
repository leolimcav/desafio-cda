using desafio_cda.api.DTO;
using desafio_cda.api.Models;
using desafio_cda.api.Repositories.Context;
using desafio_cda.api.Repositories.Interfaces;

namespace desafio_cda.api.Repositories.Implementations;

public class StatusRepository : IStatusRepository
{
  private readonly AppDbContext _context;

  public StatusRepository(AppDbContext context)
  {
    _context = context;
  }
  public async Task<Status> CreateAsync(CreateStatusDTO entity)
  {
    var createdStatus = _context.Status.Add(new Status()
    {
      Name = entity.Name,
    }).Entity;

    await _context.SaveChangesAsync();

    return createdStatus;
  }
}
