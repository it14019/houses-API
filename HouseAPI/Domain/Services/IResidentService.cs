using HouseAPI.Domain.Models;
using HouseAPI.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseAPI.Domain.Services
{
    public interface IResidentService
    {
        Task<IEnumerable<Resident>> ListAsync();
        Task<ResidentResponse> SaveAsync(Resident resident);
        Task<ResidentResponse> UpdateAsync(int id, Resident resident);
        Task<ResidentResponse> DeleteAsync(int id);
    }
}
