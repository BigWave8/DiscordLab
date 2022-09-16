using Discord.Dto;
using Discord.Interfaces.Repository;
using Discord.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<IEnumerable<UserDto>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Task<UserDto> GetById(string id)
        {
            return _userRepository.GetById(id);
        }

        public Task<string> Insert(UserDto user)
        {
            return _userRepository.Insert(user);
        }

        public Task Update(UserDto user)
        {
            return _userRepository.Update(user);
        }

        public Task Delete(string id)
        {
            return _userRepository.Delete(id);
        }
    }
}
