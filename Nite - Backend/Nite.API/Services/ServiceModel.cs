﻿using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using Nite.API.Data.Models;
using Nite.API.Repository;
using Nite.API.Repository.Entities;

namespace Nite.API.Services
{
    public class ServiceModel : IServiceModel
    {
        private readonly ILoginSignupRepository _loginSignupRepository;
        private readonly IMapper _mapper;


        public ServiceModel(ILoginSignupRepository loginSignupRepository, IMapper mapper)
        {
            _loginSignupRepository = loginSignupRepository ?? throw new ArgumentNullException(nameof(loginSignupRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public UserDTO? LoginRequestService(LoginDTO request) 
        {
            var user = _loginSignupRepository.LoginRequest(request);

            if(user == null) 
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetUsersService()
        {
            var result = _loginSignupRepository.GetUsers();
            return _mapper.Map<IEnumerable<UserDTO>>(result);
        }

        public UserDTO GetUserService(int id) 
        {
            var result = _loginSignupRepository.GetUser(id);

            return _mapper.Map<UserDTO>(result);
        }

        public UserDTO AddUserService(UserCreationDTO user)
        {
            var result = _mapper.Map<User>(user);

            _loginSignupRepository.AddUser(result);
            _loginSignupRepository.Save();

            return _mapper.Map<UserDTO>(result);
        }


        public void UpdateWithPutUser(int userId, UserUpdateDTO user)
        {
            var userEntity = _loginSignupRepository.GetUser(userId);
            _mapper.Map(user, userEntity);
        }

        public UserUpdateDTO UpdateWithPatchUser(int id)
        {
            var userEntity = _loginSignupRepository.GetUser(id);
            return _mapper.Map<UserUpdateDTO>(userEntity);
        }

        public void UpdateUserFinishService(int id, UserUpdateDTO userToPatch)
        {
            var userEntity = _loginSignupRepository.GetUser(id);
            _mapper.Map(userToPatch, userEntity);
        }

        public void DeleteUserService(int id)
        {
            var userEntity = _loginSignupRepository.GetUser(id);

            _loginSignupRepository.DeleteUser(userEntity);

            _loginSignupRepository.Save();
        }



        public bool UserExistService(int userId)
        {
            return _loginSignupRepository.UserExist(userId);
        }

        public bool SaveService()
        {
            return _loginSignupRepository.Save();
        }
    }
}
