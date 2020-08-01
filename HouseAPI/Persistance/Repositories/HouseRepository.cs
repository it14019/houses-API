using HouseAPI.Domain.Models;
using HouseAPI.Domain.Repositories;
using HouseAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseAPI.Persistance.Repositories
{
    public class HouseRepository : BaseRepository, IHouseRepository
    {
        public HouseRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<House>> ListAsync()
        {
            return await _context.Houses.ToListAsync();
        }

        public async Task AddAsync(House house)
        {
            await _context.Houses.AddAsync(house);
        }

        public async Task<House> FindByIdAsync(int id)
        {
            return await _context.Houses.FindAsync(id);
        }

        public void Update(House house)
        {
            _context.Houses.Update(house);
        }

        public void Remove(House house)
        {
            _context.Houses.Remove(house);
        }
    }
}
