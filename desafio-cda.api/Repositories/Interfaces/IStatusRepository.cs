using desafio_cda.api.DTO;
using desafio_cda.api.Models;

namespace desafio_cda.api.Repositories.Interfaces;

public interface IStatusRepository
{
  Task<Status> CreateAsync(CreateStatusDTO entity);
}
