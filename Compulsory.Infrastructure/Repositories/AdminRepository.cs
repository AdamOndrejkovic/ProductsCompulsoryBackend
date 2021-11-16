using System.Collections.Generic;
using System.Linq;
using Compulsory.Core.Models;
using Compulsory.Domain.IRepository;
using Compulsory.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

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

        public bool Register(string username, byte[] passwordHash, byte[] passwordSalt)
        {
            var adminEntity = new AdminEntity()
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CanUpdate = false,
                CanCreate = false,
                CanDelete = true, 
            };
            _context.Admins.Attach(adminEntity).State = EntityState.Added;
            _context.SaveChanges();
            return true;
        }
    }
}