using HouseAPI.Domain.Models;
using HouseAPI.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseAPI.Domain.Services
{
    public interface IHouseService
    {
        Task<IEnumerable<House>> ListAsync();
        Task<HouseResponse> SaveAsync(House house);
        Task<HouseResponse> UpdateAsync(int id, House house);
        Task<HouseResponse> DeleteAsync(int id);
    }
}
