using desafio_cda.api.DTO;
using desafio_cda.api.Models;
using desafio_cda.api.Repositories.Context;
using desafio_cda.api.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace desafio_cda.api.Repositories.Implementations;

public class CriminalCodeRepository : ICriminalCodeRepository
{
  private readonly AppDbContext _context;

  public CriminalCodeRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<CriminalCode>> GetAllAsync(string? orderBy, FilterCriminalCode filters, PaginationFilter paginationFilter)
  {
    var criminalCodesQuery = _context.CriminalCodes.AsQueryable();
    criminalCodesQuery = ApplyFiltering(filters, criminalCodesQuery);
    criminalCodesQuery = ApplyOrdering(orderBy, criminalCodesQuery);

    var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
    
    var criminalCodes = await criminalCodesQuery.Skip(skip).Take(paginationFilter.PageSize).ToListAsync();
    return criminalCodes;
  }

  public async Task<CriminalCode?> GetByIdAsync(long id)
  {
    return await _context.CriminalCodes.FirstOrDefaultAsync(x => x.Id == id);
  }

  public async Task<CriminalCode?> SaveAsync(CreateCriminalCodeDTO entity)
  {
    var criminalCodeExists = await _context.CriminalCodes.FirstOrDefaultAsync(x => x.Name == entity.Name);

    if (criminalCodeExists is not null)
    {
      return null;
    }
    
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

  public async Task<CriminalCode?> UpdateAsync(long id, UpdateCriminalCodeDTO entity)
  {
    var criminalCode = await _context.CriminalCodes.FirstOrDefaultAsync(x => x.Id == id);

    if (criminalCode is null)
    {
      return null;
    }

    criminalCode.Name = entity.Name;
    criminalCode.Description = entity.Description;
    criminalCode.Penalty = entity.Penalty;
    criminalCode.PrisonTime = entity.PrisonTime;
    criminalCode.CreateUserId = entity.CreateUserId;
    criminalCode.UpdateUserId = entity.UpdateUserId;
    criminalCode.StatusId = entity.StatusId;
    
    var updatedCriminalCode = _context.CriminalCodes.Update(criminalCode).Entity;

    await _context.SaveChangesAsync();

    return updatedCriminalCode;
  }

  public async Task<CriminalCode?> RemoveAsync(long id)
  {
    var criminalCode = await _context.CriminalCodes.FirstOrDefaultAsync(x => x.Id == id);

    if (criminalCode is null)
    {
      return null;
    }

    _context.CriminalCodes.Remove(criminalCode);
    await _context.SaveChangesAsync();

    return criminalCode;
  }
  
  private static IQueryable<CriminalCode> ApplyFiltering(FilterCriminalCode filters, IQueryable<CriminalCode> criminalCodesQuery)
  {
    IQueryable<CriminalCode> filterQuery = criminalCodesQuery;
    if (filters.Id.HasValue)
    {
      filterQuery = criminalCodesQuery.Where(x => x.Id == filters.Id);
    }
    else if (!string.IsNullOrEmpty(filters.Name))
    {
      filterQuery = criminalCodesQuery.Where(x => x.Name == filters.Name);
    }
    else if (!string.IsNullOrEmpty(filters.Description))
    {
      filterQuery = criminalCodesQuery.Where(x => x.Description == filters.Description);
    }
    else if (filters.Penalty.HasValue)
    {
      filterQuery = criminalCodesQuery.Where(x => x.Penalty == filters.Penalty.Value);
    }
    else if (filters.PrisonTime.HasValue)
    {
      filterQuery = criminalCodesQuery.Where(x => x.PrisonTime == filters.PrisonTime.Value);
    }else if (filters.StatusId.HasValue)
    {
      filterQuery = criminalCodesQuery.Where(x => x.StatusId == filters.StatusId.Value);
    }else if (filters.CreateUserId.HasValue)
    {
      filterQuery = criminalCodesQuery.Where(x => x.CreateUserId == filters.CreateUserId.Value);
    }else if (filters.UpdateUserId.HasValue)
    {
      filterQuery = criminalCodesQuery.Where(x => x.UpdateUserId == filters.UpdateUserId.Value);
    }else if (filters.CreatedAt.HasValue)
    {
      filterQuery = criminalCodesQuery.Where(x => x.CreatedAt.Date >= filters.CreatedAt.Value.Date);
    }else if (filters.UpdatedAt.HasValue)
    {
      filterQuery = criminalCodesQuery.Where(x => x.UpdatedAt.Date >= filters.UpdatedAt.Value.Date);
    }

    return filterQuery;
  }
  
  private static IQueryable<CriminalCode> ApplyOrdering(string? orderBy, IQueryable<CriminalCode> criminalCodesQuery)
  {
    IQueryable<CriminalCode> orderingQuery = criminalCodesQuery;
    
    if (!string.IsNullOrEmpty(orderBy))
    {
      var splittedString = orderBy.Split(":");
      var field = splittedString[0];
      var orientation = splittedString[1];

      switch (field.ToLower())
      {
        case "id":
          if (orientation.ToLower().Equals("desc"))
          {
            orderingQuery = criminalCodesQuery.OrderByDescending(x => x.Id);
          }
          else
          {
            orderingQuery = criminalCodesQuery.OrderBy(x => x.Id);
          }
          break;
        case "name":
          if (orientation.ToLower().Equals("desc"))
          {
            orderingQuery = criminalCodesQuery.OrderByDescending(x => x.Name);
          }
          else
          {
            orderingQuery = criminalCodesQuery.OrderBy(x => x.Name);
          }
          break;
        case "description":
          if (orientation.ToLower().Equals("desc"))
          {
            orderingQuery = criminalCodesQuery.OrderByDescending(x => x.Description);
          }
          else
          {
            orderingQuery = criminalCodesQuery.OrderBy(x => x.Description);
          }
          break;
        case "penalty":
          if (orientation.ToLower().Equals("desc"))
          {
            orderingQuery = criminalCodesQuery.OrderByDescending(x => x.Penalty);
          }
          else
          {
            orderingQuery = criminalCodesQuery.OrderBy(x => x.Penalty);
          }
          break;
        case "prisontime":
          if (orientation.ToLower().Equals("desc"))
          {
            orderingQuery = criminalCodesQuery.OrderByDescending(x => x.PrisonTime);
          }
          else
          {
            orderingQuery = criminalCodesQuery.OrderBy(x => x.PrisonTime);
          }
          break;
        case "statusid":
          if (orientation.ToLower().Equals("desc"))
          {
            orderingQuery = criminalCodesQuery.OrderByDescending(x => x.StatusId);
          }
          else
          {
            orderingQuery = criminalCodesQuery.OrderBy(x => x.StatusId);
          }
          break;
        case "createuserid":
          if (orientation.ToLower().Equals("desc"))
          {
            orderingQuery = criminalCodesQuery.OrderByDescending(x => x.CreateUserId);
          }
          else
          {
            orderingQuery = criminalCodesQuery.OrderBy(x => x.CreateUserId);
          }
          break;
        case "updateuserid":
          if (orientation.ToLower().Equals("desc"))
          {
            orderingQuery = criminalCodesQuery.OrderByDescending(x => x.UpdateUserId);
          }
          else
          {
            orderingQuery = criminalCodesQuery.OrderBy(x => x.UpdateUserId);
          }
          break;
        case "createdat":
          if (orientation.ToLower().Equals("desc"))
          {
            orderingQuery = criminalCodesQuery.OrderByDescending(x => x.CreatedAt);
          }
          else
          {
            orderingQuery = criminalCodesQuery.OrderBy(x => x.CreatedAt);
          }
          break;
        case "updatedat":
          if (orientation.ToLower().Equals("desc"))
          {
            orderingQuery = criminalCodesQuery.OrderByDescending(x => x.UpdatedAt);
          }
          else
          {
            orderingQuery = criminalCodesQuery.OrderBy(x => x.UpdatedAt);
          }
          break;
      }
    }

    return orderingQuery;
  }
}
