using AutoMapper;
using MedicineManager.Data;
using MedicineManager.Models;
using MedicineManager.Models.CustomerRequest;

namespace MedicineManager.Services.Customer
{
    public class AddressServices 
    {
        private AddressRepository _repo;
        private UserRepository _userRepo;
        private CityRepository _cityRepository;
        private DistrictRepository _districtRepository;
        private WardRepository _wardRepository;
        private IMapper _mapper;
        public AddressServices(AddressRepository repo, UserRepository userRepo, CityRepository city,
            DistrictRepository districtRepository, WardRepository wardRepository,IMapper mapper)
        {
            _repo = repo;
            _userRepo = userRepo;
            _cityRepository = city;
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
            _mapper = mapper;
        }

        public async Task<ReponseDto> CreateOrUpdateAddress(AddressRequest address)
        {
            
            var add = await _repo.GetById(address.Id);
            var user = await _userRepo.FindUser(address.UserId);
            var city= await _cityRepository.getById(address.CityId);
            var district = await _districtRepository.getById(address.DistrictId);
            var ward = await _wardRepository.getById(address.WardId);
            if(user == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist user with id={address.UserId}",
                    isSuccess = false
                };
            }
            if(city == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist city with id={address.CityId}",
                    isSuccess = false
                };
            }
            if(district == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist district with id={address.DistrictId}",
                    isSuccess = false
                };
            }
            
            if(ward == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist ward with id={address.WardId}",
                    isSuccess = false
                };
            }
            if(ward.DistrictId != district.Id || district.CityId !=city.Id) {
                return new ReponseDto
                {
                    Message = $"Invalid address",
                    isSuccess = false
                };
            }
            var addr = _mapper.Map<Address>(address);
            if (add == null)
            {
                var ar = await _repo.Add(addr);
                return new ReponseDto
                {
                    Message = "Create new address success",
                    isSuccess = true,
                    Data = ar
                };
            }
            var upd= await _repo.UpdateAddress(addr);
            return new ReponseDto
            {
                Message = "Update Success",
                isSuccess = true,
                Data = upd
            };
        }

        public async Task<ReponseDto> GetAll()
        {
            var address= await _repo.GetAll();
            return new ReponseDto
            {
                Message="Get all is successful",
                isSuccess=true,
                Data = address
            };
        }

        public async Task<ReponseDto> GetById(int id)
        {
            var addre= await _repo.GetById(id);
            if(addre == null)
            {
                return new ReponseDto
                {
                    Message=$"Not exist address with id={id}",
                    isSuccess = false
                };
            }
            return new ReponseDto
            {
                Message = "Get address successful",
                isSuccess = true,
                Data= addre
            };
        }

        public async Task<ReponseDto> DeleteAddress(int id)
        {
            var address = await _repo.GetById(id);
            if(address == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist address with id={id}",
                    isSuccess = false
                };
            }
            await _repo.DeleteAddress(address);
            return new ReponseDto
            {
                Message = "Delete address success",
                isSuccess = true,
            };
        }

        public async Task<ReponseDto> GetByUser(int userId)
        {
            var user = await _userRepo.FindUser(userId);
            if(user == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist user with id={userId}",
                    isSuccess = false
                };

            }
            var address = await _repo.FindByUser(userId);
            if (address == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist address for user has id={userId}",
                    isSuccess = false
                };
            }
            return new ReponseDto
            {
                Message = $"Get address by user is successful",
                isSuccess = true,
                Data=address
            };
        }

    }
}
