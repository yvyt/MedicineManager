using AutoMapper;
using MedicineManager.Data;
using MedicineManager.Models.CustomerRequest;

namespace MedicineManager.Services.Customer
{
    public class MapperCustomer : Profile
    {
        public MapperCustomer() {
            CreateMap<AddressRequest, Address>();
            CreateMap<UserRequest, User>();
            CreateMap<CityRequest,City>();
            CreateMap<DistrictRequest, District>();
        }
    }
}
