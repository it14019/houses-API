using HouseAPI.Domain.Models;
using HouseAPI.Domain.Repositories;
using HouseAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseAPI.Persistance.Repositories
{
    public class ResidentRespository : BaseRepository, IResidentRepository
    {
        public ResidentRespository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Resident>> ListAsync()
        {
            return await _context.Residents.Include(p => p.Apartment).ThenInclude(p => p.House).ToListAsync();
        }

        public async Task AddAsync(Resident resident)
        {
            await _context.Residents.AddAsync(resident);
        }

        public async Task<Resident> FindByIdAsync(int id)
        {
            return await _context.Residents.FindAsync(id);
        }
        public void Update(Resident resident)
        {
            _context.Residents.Update(resident);
        }

        public void Remove(Resident resident)
        {
            _context.Residents.Remove(resident);
        }
    }
}
