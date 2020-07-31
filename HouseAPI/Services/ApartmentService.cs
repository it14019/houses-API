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
    public class ApartmentService: IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentService(IApartmentRepository apartmentRepository, IUnitOfWork unitOfWork)
        {
            _apartmentRepository = apartmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Apartment>> ListAsync()
        {
            return await _apartmentRepository.ListAsync();
        }

        public async Task<ApartmentResponse> SaveAsync(Apartment apartment)
        {
            try
            {
                await _apartmentRepository.AddAsync(apartment);
                await _unitOfWork.CompleteAsync();

                return new ApartmentResponse(apartment);
            }
            catch (Exception ex)
            {
                return new ApartmentResponse($"An error occured when saving the house: {ex.Message}");
            }
        }

        public async Task<ApartmentResponse> UpdateAsync(int id, Apartment apartment)
        {
            var existingApartment = await _apartmentRepository.FindByIdAsync(id);

            if (existingApartment == null)
                return new ApartmentResponse("Apartment not find");

            existingApartment.Number = apartment.Number;
            existingApartment.Rooms = apartment.Rooms;
            existingApartment.PropertySize = apartment.PropertySize;
            existingApartment.LivingArea = apartment.LivingArea;

            try
            {
                _apartmentRepository.Update(existingApartment);
                await _unitOfWork.CompleteAsync();

                return new ApartmentResponse(existingApartment);
            }

            catch (Exception ex)
            {
                return new ApartmentResponse($"An error occured when updatingthe apartment: {ex.Message}");
            }
        }

        public async Task<ApartmentResponse> DeleteAsync(int id)
        {
            var existingApartment = await _apartmentRepository.FindByIdAsync(id);

            if (existingApartment == null)
                return new ApartmentResponse("Apartment not found.");

            try
            {
                _apartmentRepository.Remove(existingApartment);
                await _unitOfWork.CompleteAsync();

                return new ApartmentResponse(existingApartment);
            }

            catch (Exception ex)
            {
                return new ApartmentResponse($"An error occured when deleting the apartment: {ex.Message}");
            }
        }

    }
}
