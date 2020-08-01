using HouseAPI.Domain.Models;
using HouseAPI.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseAPI.Domain.Services
{
    public interface IApartmentService
    {
        Task<IEnumerable<Apartment>> ListAsync();
        Task<ApartmentResponse> SaveAsync(Apartment apartment);
        Task<ApartmentResponse> UpdateAsync(int id, Apartment apartment);
        Task<ApartmentResponse> DeleteAsync(int id);
    }
}
