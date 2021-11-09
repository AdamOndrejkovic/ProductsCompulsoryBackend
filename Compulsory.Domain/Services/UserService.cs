using System.IO;
using Compulsory.Domain.IRepository;

namespace Compulsory.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            if (userRepository == null)
            {
                throw new InvalidDataException("IUserRepository must be in constructor");
            }
            _userRepository = userRepository;
        }
    }
}