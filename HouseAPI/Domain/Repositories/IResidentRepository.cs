using HouseAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseAPI.Domain.Repositories
{
    public interface IResidentRepository
    {
        Task<IEnumerable<Resident>> ListAsync();
        Task AddAsync(Resident resident);
        Task<Resident> FindByIdAsync(int id);
        void Update(Resident resident);
        void Remove(Resident resident);
    }
}
