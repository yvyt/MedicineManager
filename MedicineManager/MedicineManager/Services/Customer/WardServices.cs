using AutoMapper;
using MedicineManager.Data;
using MedicineManager.Models;
using MedicineManager.Models.CustomerRequest;

namespace MedicineManager.Services.Customer
{
    public class WardServices
    {
        private readonly WardRepository _repository;
        private readonly IMapper _mapper;
        private readonly DistrictRepository _district;
        public WardServices(WardRepository repository, IMapper mapper,DistrictRepository district)
        {
            _repository = repository;
            _mapper = mapper;
            _district = district;
        }

        public async Task<ReponseDto> CreateOrUpdate(WardRequest ward)
        {
            var vali = await ValidateRequest(ward.DistrictId);
            if (!vali.isSuccess)
            {
                return vali;
            }
            var w = _mapper.Map<Ward>(ward);
            var wa= await _repository.getById(ward.Id);
            if(wa== null)
            {
                var result = await _repository.Add(w);
                return new ReponseDto
                {
                    Message = "Create new ward successful",
                    isSuccess = true,
                    Data = result
                };
            }
            var r = await _repository.Update(w);
            return new ReponseDto
            {
                Message = "Update ward successful",
                isSuccess = true,
                Data = r
            };

        }

        public async Task<ReponseDto> GetAll()
        {
            var data = await _repository.getAll();
            if (data.Count == 0)
            {
                return new ReponseDto
                {
                    Message = $"Not exist any ward in system",
                    isSuccess = false
                };
            }
            return new ReponseDto
            {
                Message = $"Get all ward successful",
                isSuccess = true, 
                Data= data
            };
        }
        public async Task<ReponseDto> GetById(int wardId)
        {
            var ward= await _repository.getById(wardId);
            if (ward == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist ward with id={wardId}",
                    isSuccess = false
                };
            }
            return new ReponseDto
            {
                Message = "Get ward successful",
                isSuccess = true,
                Data = ward
            };
        }
        private async Task<ReponseDto> ValidateRequest(int district_id)
        {
           var c = await _district.getById(district_id);
            if (c == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist district with id={district_id}",
                    isSuccess = false,
                };
            }

            return new ReponseDto
            {
                Message = $"Get district suceess",
                isSuccess = true,
                Data = c
            };
        }
        public async Task<ReponseDto> getByDistrict(int district_id)
        {
            var c = await ValidateRequest(district_id);
            if (!c.isSuccess)
            {
                return c;
            }
            var district = await _repository.getByDistrictId(district_id);
            if (district.Count == 0)
            {
                return new ReponseDto
                {
                    Message = $"Not exist any ward with district id={district_id}",
                    isSuccess = false
                };
            }
            return new ReponseDto
            {
                Message = $"Get ward with district id successful",
                isSuccess = true,
                Data = district
            };
        }

        public async Task<ReponseDto> DeleteWard(int id)
        {
            var w = await _repository.getById(id);
            if (w == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist ward with id={id}",
                    isSuccess = false
                };
            }

            await _repository.Delete(w);
            return new ReponseDto
            {
                Message = "Delete ward and related successful",
                isSuccess = true,
            };
        }
    }
}
