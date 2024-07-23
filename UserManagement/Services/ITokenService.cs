using Data.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Services
{
    public interface ITokenService
    {
        string createToken(User user);
    }
}
