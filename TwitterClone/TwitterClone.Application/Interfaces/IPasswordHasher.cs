using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(UserDto user, string password);
        bool VerifyPassword(UserDto user, string passwordHash, string password);
    }
}
