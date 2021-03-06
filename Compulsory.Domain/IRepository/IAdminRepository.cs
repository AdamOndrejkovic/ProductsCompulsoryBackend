using System.Collections.Generic;
using Compulsory.Core.Models;

namespace Compulsory.Domain.IRepository
{
    public interface IAdminRepository
    {
        List<Admin> GetAll();
        bool Register(string username, byte[] passwordHash, byte[] passwordSalt);
    }
}