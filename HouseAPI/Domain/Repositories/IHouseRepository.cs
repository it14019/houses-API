using HouseAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseAPI.Domain.Repositories
{
   public interface IHouseRepository
    {
        Task<IEnumerable<House>> ListAsync();
        Task AddAsync(House house);
        Task<House> FindByIdAsync(int id);
        void Update(House house);
        void Remove(House house);
    }
}
