using System.IO;
using Compulsory.Core.IServices;
using Compulsory.Domain.IRepository;

namespace Compulsory.Domain.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository ?? throw new InvalidDataException("Admin repository can not be null");
        }
    }
}