using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1_idwm.src.Data;
using Catedra1_idwm.src.Interfaces;
using Catedra1_idwm.src.Models;

namespace Catedra1_idwm.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        
        public Task<User> Post(User user)
        {
            throw new NotImplementedException();
        }
        
    }
}