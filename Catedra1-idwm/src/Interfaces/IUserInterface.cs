using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1_idwm.src.DTOs;
using Catedra1_idwm.src.Models;

namespace Catedra1_idwm.src.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsByRut(string rut);
        Task<User> Post(User user);
        Task<List<User>> GetAll(string? sort, string? gender);
        Task<User?> Put(int id, UpdateUserDto updateUserDto);
        Task<User?> Delete(int id);
    }
}