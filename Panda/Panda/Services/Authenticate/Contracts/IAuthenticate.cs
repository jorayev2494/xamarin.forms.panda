using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Panda.Services.Authenticate.Contracts
{
    public interface IAuthenticate
    {
        Task<bool> Registration(object data);
        Task<bool> Login(object data);
        Task<bool> Logout();
    }
}
