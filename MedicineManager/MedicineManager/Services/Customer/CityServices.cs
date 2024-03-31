using AutoMapper;
using MedicineManager.Data;
using MedicineManager.Models;
using MedicineManager.Models.CustomerRequest;

namespace MedicineManager.Services.Customer
{
    public class CityServices
    {
        private readonly CityRepository _repo;
        private readonly IMapper _mapper;
        private readonly DistrictRepository _districtRepo;
        public CityServices(CityRepository repo, IMapper mapper, DistrictRepository districtRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _districtRepo = districtRepo;
        }

        internal async Task<ReponseDto> CreateOrUpdateCity(CityRequest city)
        {
            var c= await _repo.getById(city.Id);
            var ct= _mapper.Map<City>(city);
            if(c==null)
            {
                var cty= await _repo.Add(ct);
                return new ReponseDto
                {
                    Message = "Create city is successful",
                    isSuccess = true,
                    Data = cty
                };
            }
            var ctUpdate = await _repo.Update(c);
            return new ReponseDto
            {
                Message = "Update city is successful",
                isSuccess = true,
                Data = ctUpdate
            };
        }

        internal async Task<ReponseDto> DeleteCity(int id)
        {
            var ct= await _repo.getById(id);
            if (ct == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist city with id={id}",
                    isSuccess = false
                };
            }
            await _repo.Delete(ct);
            return new ReponseDto
            {
                Message="Delete city and related successful",
                isSuccess = true,
            };
        }

        internal async Task<ReponseDto> GetAll()
        {
            var result = await _repo.getAll();
            if (result.Count==0)
            {
                return new ReponseDto
                {
                    Message = $"Not exist any city in system",
                    isSuccess = false
                };
            }
            return new ReponseDto
            {
                Message = "Get all city successful",
                isSuccess = true,
                Data = result
            };
        }

        internal async Task<ReponseDto> GetById(int city_Id)
        {
            var data = await _repo.getById(city_Id);
            if (data == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist city with id={city_Id}",
                    isSuccess = false
                };
            }
            return new ReponseDto
            {
                Message = "Get city successful",
                isSuccess = true,
                Data = data
            };
        }
    }
}
