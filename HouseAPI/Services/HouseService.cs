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
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HouseService(IHouseRepository houseRepository, IUnitOfWork unitOfWork)
        {
            _houseRepository = houseRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<House>> ListAsync()
        {
            return await _houseRepository.ListAsync();
        }

        public async Task<HouseResponse> SaveAsync(House house)
        {
            try
            {
                await _houseRepository.AddAsync(house);
                await _unitOfWork.CompleteAsync();

                return new HouseResponse(house);
            }
            catch (Exception ex)
            {
                return new HouseResponse($"An error occured when saving the house: {ex.Message}");
            }
        }

        public async Task<HouseResponse> UpdateAsync(int id, House house)
        {
            var existingHouse = await _houseRepository.FindByIdAsync(id);

            if (existingHouse == null)
                return new HouseResponse("House not find");

            existingHouse.Street = house.Street;
            existingHouse.Number = house.Number;
            existingHouse.City = house.City;
            existingHouse.Country = house.Country;
            existingHouse.PostCode = house.PostCode;

            try
            {
                _houseRepository.Update(existingHouse);
                await _unitOfWork.CompleteAsync();

                return new HouseResponse(existingHouse);
            }

            catch (Exception ex)
            {
                return new HouseResponse($"An error occured when updatingthe house: {ex.Message}");

            }
        }

        public async Task<HouseResponse> DeleteAsync(int id)
        {
            var existingHouse = await _houseRepository.FindByIdAsync(id);

            if (existingHouse == null)
                return new HouseResponse("House not found.");

            try
            {
                _houseRepository.Remove(existingHouse);
                await _unitOfWork.CompleteAsync();

                return new HouseResponse(existingHouse);
            }

            catch (Exception ex)
            {
                return new HouseResponse($"An error occured when deleting the house: {ex.Message}");
            }
        }
    }
}
