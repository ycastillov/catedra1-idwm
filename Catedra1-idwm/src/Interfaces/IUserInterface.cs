using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1_idwm.src.Models;

namespace Catedra1_idwm.src.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Post(User user);
    }
}