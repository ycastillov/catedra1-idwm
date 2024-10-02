using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1_idwm.src.Data;
using Catedra1_idwm.src.Interfaces;
using Catedra1_idwm.src.Models;
using Microsoft.EntityFrameworkCore;

namespace Catedra1_idwm.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> ExistsByRut(string rut)
        {
            return await _dataContext.Users.AnyAsync(u => u.Rut == rut);
        }

        public async Task<User> Post(User user)
        {
            await _dataContext.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
        
    }
}