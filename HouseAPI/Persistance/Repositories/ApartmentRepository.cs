using HouseAPI.Domain.Models;
using HouseAPI.Domain.Repositories;
using HouseAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseAPI.Persistance.Repositories
{
    public class ApartmentRepository : BaseRepository, IApartmentRepository
    {
        public ApartmentRepository(AppDbContext context) : base(context) {}

        public async Task<IEnumerable<Apartment>> ListAsync()
        {
            return await _context.Apartments.Include(p => p.House)
                .ToListAsync();
        }

        public async Task AddAsync(Apartment apartment)
        {
            await _context.Apartments.AddAsync(apartment);
        }

        public async Task<Apartment> FindByIdAsync(int id)
        {
            return await _context.Apartments.FindAsync(id);
        }
        public void Update(Apartment apartment)
        {
            _context.Apartments.Update(apartment);
        }

        public void Remove(Apartment apartment)
        {
            _context.Apartments.Remove(apartment);
        }
    }
}
