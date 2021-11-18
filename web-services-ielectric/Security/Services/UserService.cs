using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Domain.Repositories;
using web_services_ielectric.Security.Authorization.Handlers.Implementation;
using web_services_ielectric.Security.Authorization.Handlers.Interfaces;
using web_services_ielectric.Security.Domain.Entities;
using web_services_ielectric.Security.Domain.Repositories;
using web_services_ielectric.Security.Domain.Services;
using web_services_ielectric.Security.Domain.Services.Communication;
using web_services_ielectric.Shared.Exceptions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace web_services_ielectric.Security.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);

            if (user == null || !BCryptNet.Verify(request.Password, user.HashPassword))
                throw new AppException("Email or password is incorrect.");

            var response = _mapper.Map<AuthenticateResponse>(user);

            response.Token = _jwtHandler.GenerateToken(user);

            return response;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }


        public async Task<User> GetByIdAsync(long id)
        {
            var user = await _userRepository.FindByIdAsync(id);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            return user;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            //validate
            if (_userRepository.ExistsByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken");

            //Map request to User model
            var user = _mapper.Map<User>(request);

            //Hash Password
            user.HashPassword = BCryptNet.HashPassword(request.Password);

            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
            }
            catch(Exception e)
            {
                throw new AppException($"An error occurred while saving user: {e.Message}");
            }
        }

        public async Task UpdateAsync(long id, UpdateRequest request)
        {
            var user = GetById(id);

            //Validate
            if (_userRepository.ExistsByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken.");

            //If password is not null, then hash it
            if (!string.IsNullOrEmpty(request.Password))
                user.HashPassword = BCryptNet.HashPassword(request.Password);

            //Map to User model
            _mapper.Map(request, user);

            try
            {
                _userRepository.Update(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updatding user: {e.Message}");
            }
        }

        public async Task DeleteAsync(long id)
        {
            var user = GetById(id);

            try
            {
                _userRepository.Remove(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting user: {e.Message}");
            }
        }
       
        public User GetById(long id)
        {
            var user = _userRepository.FindById(id);

            if (user == null)
                throw new KeyNotFoundException("User not found.");

            return user;
        }

    }
}
