using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Security.Domain.Entities;
using web_services_ielectric.Security.Domain.Services;
using web_services_ielectric.Security.Domain.Services.Communication;
using web_services_ielectric.Security.Middleware.Implementation;
using web_services_ielectric.Shared.Settings;

namespace web_services_ielectric.Security.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Sebas", LastName = "Bran", Email = "sebas@gmail.com", HashPassword = "sebas12345" }
        };

        private readonly JwtUtility _jwtUtility;

        public UserService(JwtUtility jwtUtility)
        {
            _jwtUtility = jwtUtility;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var user = _users.SingleOrDefault(p => p.Email == request.Email && p.HashPassword == request.Password);

            if (user == null)
                return null;

            var token = _jwtUtility.GenerateToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(p => p.Id == id);
        }
    }
}
