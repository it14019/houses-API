using HouseAPI.Domain.Models;
using HouseAPI.Domain.Repositories;
using HouseAPI.Domain.Services;
using HouseAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseAPI.Services
{
    public class ResidentService : IResidentService
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ResidentService(IResidentRepository residentRepository, IUnitOfWork unitOfWork)
        {
            _residentRepository = residentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Resident>> ListAsync()
        {
            return await _residentRepository.ListAsync();
        }

        public async Task<ResidentResponse> SaveAsync(Resident resident)
        {
            try
            {
                await _residentRepository.AddAsync(resident);
                await _unitOfWork.CompleteAsync();

                return new ResidentResponse(resident);
            }
            catch (Exception ex)
            {
                return new ResidentResponse($"An error occured when saving the resident: {ex.Message}");
            }
        }

        public async Task<ResidentResponse> UpdateAsync(int id, Resident resident)
        {
            var existingResident = await _residentRepository.FindByIdAsync(id);

            if (existingResident == null)
                return new ResidentResponse("Resident not found");

            existingResident.Surname = resident.Surname;
            existingResident.Phone = resident.Phone;
            existingResident.Mail = resident.Mail;
/*            existingResident.PersonalCode = resident.PersonalCode;
            existingResident.BirthDate = resident.BirthDate;
*/
            try
            {
                _residentRepository.Update(existingResident);
                await _unitOfWork.CompleteAsync();

                return new ResidentResponse(existingResident);
            }

            catch (Exception ex)
            {
                return new ResidentResponse($"An error occured when updating the resident: {ex.Message}");
            }
        }

        public async Task<ResidentResponse> DeleteAsync(int id)
        {
            var existingResident = await _residentRepository.FindByIdAsync(id);

            if (existingResident == null)
                return new ResidentResponse("Resident not found.");

            try
            {
                _residentRepository.Remove(existingResident);
                await _unitOfWork.CompleteAsync();

                return new ResidentResponse(existingResident);
            }

            catch (Exception ex)
            {
                return new ResidentResponse($"An error occured when deleting the resident: {ex.Message}");
            }
        }
    }
}
