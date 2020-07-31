using HouseAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
