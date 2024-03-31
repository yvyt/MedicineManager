using AutoMapper;
using MedicineManager.Data;
using MedicineManager.Models;
using MedicineManager.Models.CustomerRequest;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace MedicineManager.Services.Customer
{

    public class UserServices 
    {
        private readonly UserRepository _repo;
        private readonly IMapper _mapper;
        private readonly AddressRepository _addreRepo;
        public UserServices(UserRepository repo, IMapper mapper, AddressRepository addreRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _addreRepo = addreRepo;
        }

        public async Task<ReponseDto> CreateOrUpdateUser(UserRequest user)
        {
            var us = await _repo.FindUser(user.Id);
            var u = _mapper.Map<User>(user);
            if(us == null) {
                var result = await _repo.Add(u);
                return new ReponseDto
                {
                    Message = "Create user is successful",
                    isSuccess = true,
                    Data = user
                };
            }
            await _repo.UpdateUser(u);
            return new ReponseDto
            {
                Message = "Update user successful",
                isSuccess = true,
            };

        }
        
        public async Task<ReponseDto> GetAll()
        {
           var users=await _repo.GetAll();
           if(users == null)
            {
                return new ReponseDto
                {
                    Message = "Not exist any user in system",
                    isSuccess = false
                };
            }
            return new ReponseDto
            {
                Message = "Get all user is successful",
                isSuccess = true,
                Data = users
            };
        }

        public async Task<ReponseDto> GetById(int userId)
        {
            var user = await _repo.FindUser(userId);
            if (user == null)
            {
                return new ReponseDto
                {
                    Message=$"Not exist user with id= {userId}",
                    isSuccess = false,
                };
            }
            return new ReponseDto
            {
                Message = "Get user successful",
                isSuccess = true,
                Data = user
            };
        }

        public async Task<ReponseDto> InActive(int id)
        {
            var us = await _repo.FindUser(id);
            if (us == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist user with id= {id}",
                    isSuccess = false,
                };
            }
            us.IsActive = false;
            us.UpdateAt= DateTime.Now;
            var use= await _repo.UpdateUser(us);
            return new ReponseDto
            {
                Message = "InActive user successful",
                isSuccess = true,
            };
        }

        internal async Task<ReponseDto> DeleteUser(int id)
        {
            var us = await _repo.FindUser(id);
            if (us == null)
            {
                return new ReponseDto
                {
                    Message = $"Not exist user with id= {id}",
                    isSuccess = false,
                };
            }
            await _repo.DeleteUser(us);
            return new ReponseDto
            {
                Message = "Remove user and related successful",
                isSuccess = true,
            };
        }
    }
}
