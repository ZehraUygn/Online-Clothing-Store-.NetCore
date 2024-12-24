using AutoMapper;
using Business.Models;
using Business.Services.Abstract;
using DataAccess.Entities;
using DataAccess.Repository.IReq;

namespace Business.Services.Base
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            _mapper = mapper;
        }
        public bool DeleteUser(int id)
        {
            return userRepository.Delete(new User { Id = id });
        }
        public List<UserDto> GetUsers()
        {
            var response = userRepository.GetAll();
            return _mapper.Map<List<UserDto>>(response);
        }
        public UserDto GetUserById(int id)
        {
            var response = userRepository.GetById(id);
            return _mapper.Map<UserDto>(response);
        }
        public UserDto InsertUser(UserDto model)
        {
            var x = _mapper.Map<User>(model);
            User response = userRepository.Insert(x);

            return _mapper.Map<UserDto>(response);
        }
        public UserDto UpdateUser(UserDto model)
        {
            var userEntity = _mapper.Map<User>(model);
            User response = userRepository.Update(userEntity);

            return _mapper.Map<UserDto>(response);
        }
    }
}
