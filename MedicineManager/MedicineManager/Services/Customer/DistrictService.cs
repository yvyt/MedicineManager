using AutoMapper;
using MedicineManager.Data;
using MedicineManager.Models;
using MedicineManager.Models.CustomerRequest;

namespace MedicineManager.Services.Customer
{
    public class DistrictService
    {
        private readonly DistrictRepository _repo;
        private readonly CityRepository _city;
        private readonly IMapper _mapper;

        public DistrictService(DistrictRepository repo, IMapper mapper, CityRepository city)
        {
            _repo = repo;
            _mapper = mapper;
            _city = city;
        }
        public async Task<ReponseDto> CreateOrUpdateDistrict(DistrictRequest district)
        {
            var result = await ValidateRequest(district.CityId);
            if (!result.isSuccess)
            {
                return result;
            }
            var d = await _repo.getById(district.Id);
            var dis = _mapper.Map<District>(district);
            if (d == null)
            {
                var re = await _repo.Add(dis);
                return new ReponseDto
                {
                    Message = "Create new district success",
                    isSuccess = true,
                    Data = dis,
                };
            }
            var res = await _repo.Update(dis);
            return new ReponseDto
            {
                Message = "Update district success",
                isSuccess = true,
                Data = dis,
            };

        }

        public async Task<ReponseDto> GetAll()
        {
            var districts = await _repo.getAll();
            if (districts.Count == 0)
            {
                return new ReponseDto
                {
                    Message = $"Not exist any district in system",
                    isSuccess = false
                };

            }
            return new ReponseDto
            {
                Message = "Get all district success",
                isSuccess = true,
                Data = districts
            };
        }

        public async Task<ReponseDto> getDistrictById(int id)
        {
            var d= await _repo.getById(id);
            if (d == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist district with id={id}",
                    isSuccess = false
                };
            }
            return new ReponseDto
            {
                Message = "Get district successful",
                isSuccess = true,
                Data = d
            };
        }

        public async Task<ReponseDto> GetDistrictByCityId(int city_id)
        {
            var c = await ValidateRequest(city_id);
            if (!c.isSuccess) {
                return new ReponseDto
                {
                    Message = $"Not exist city with id={city_id}",
                    isSuccess = false
                };
            }
            var district = await _repo.getByCityId(city_id);
            if(district.Count==0)
            {
                return new ReponseDto
                {
                    Message = $"Not exist any district with city id={city_id}",
                    isSuccess = false
                };
            }
            return new ReponseDto
            {
                Message = $"Get district with city id successful",
                isSuccess = true, 
                Data = district
            };
        }

        private async Task<ReponseDto> ValidateRequest(int city_id)
        {
            var c = await _city.getById(city_id);
            if (c == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist city with id={city_id}",
                    isSuccess = false,
                };
            }
            return new ReponseDto
            {
                Message = $"Get city suceess",
                isSuccess = true,
                Data = c
            }; ;
        }
        public async Task<ReponseDto> DeleteDistrict(int id)
        {
            var district = await _repo.getById(id);
            if(district == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist district with id={id}",
                    isSuccess = false
                };
            }

            await _repo.Delete(district);
            return new ReponseDto
            {
                Message = "Delete district and related successful",
                isSuccess = true,
            };
        }
    }
}

