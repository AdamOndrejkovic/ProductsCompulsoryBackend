using System.Linq;
using Compulsory.Core.Models;
using Compulsory.Domain.IRepository;

namespace Compulsory.Security.Authenticator
{
    public class Authenticator: IAuthenticator
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAuthenticationHelper _authenticationHelper;

        public Authenticator(IAdminRepository adminRepository, IAuthenticationHelper authenticationHelper)
        {
            _adminRepository = adminRepository;
            _authenticationHelper = authenticationHelper;
        }
        
        public bool Login(string username, string password, out string token)
        {
            Admin admin = _adminRepository.GetAll().FirstOrDefault(admin => admin.Username.Equals(username));
            if (admin == null)
            {
                token = null;
                return false;
            }

            if (!_authenticationHelper.VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt))
            {
                token = null;
                return false;
            }

            token = _authenticationHelper.GenerateToken(admin);
            return true;
        }

        public bool Register(string loginUsername, string loginPassword)
        {

            byte[] passwordHash;
            byte[] passwordSalt;
                _authenticationHelper.CreatePasswordHash(loginPassword, out passwordHash, out passwordSalt);
            var registered =  _adminRepository.Register(loginUsername, passwordHash, passwordSalt);
            if (registered)
            {
                return true;
            }

            return false;
        }
    }
}