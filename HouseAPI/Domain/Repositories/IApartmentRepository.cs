using HouseAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseAPI.Domain.Repositories
{
    public interface IApartmentRepository
    {
        Task<IEnumerable<Apartment>> ListAsync();
        Task AddAsync(Apartment apartment);
        Task<Apartment> FindByIdAsync(int id);
        void Update(Apartment apartment);

        void Remove(Apartment apartment);
    }
}
