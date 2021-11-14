using System.Collections.Generic;
using System.Linq;
using Compulsory.Core.Models;
using Compulsory.Domain.IRepository;

namespace Compulsory.Infrastructure.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly CompulsoryContext _context;

        public AdminRepository(CompulsoryContext context)
        {
            _context = context;
        }
        public List<Admin> GetAll()
        {
            return _context.Admins.Select(a => 
                new Admin()
                {
                    Id = a.Id,
                    PasswordHash = a.PasswordHash,
                    PasswordSalt = a.PasswordSalt,
                    CanCreate = a.CanCreate,
                    CanDelete = a.CanDelete,
                    CanUpdate = a.CanUpdate
                }).ToList();
        }
    }
}