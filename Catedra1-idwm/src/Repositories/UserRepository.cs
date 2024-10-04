using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1_idwm.src.Data;
using Catedra1_idwm.src.DTOs;
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

        public async Task<List<User>> GetAll(string? sort, string? gender)
        {
            var users = _dataContext.Users.AsQueryable();

            // Filtrar por género, si se proporciona
            if (!string.IsNullOrEmpty(gender))
            {
                users = users.Where(u => u.Gender.ToLower() == gender.ToLower());
            }

            // Ordenar por nombre, si se proporciona el parámetro de ordenación
            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.ToLower() == "asc")
                {
                    users = users.OrderBy(u => u.Name);
                }
                else if (sort.ToLower() == "desc")
                {
                    users = users.OrderByDescending(u => u.Name);
                }
            }

            return await users.ToListAsync();
        }

        public async Task<User?> Put(int id, UpdateUserDto updateUserDto)
        {
            // Buscar el usuario existente por su ID
            var existingUser = await _dataContext.Users.FindAsync(id);

            // Verificar si el usuario existe
            if (existingUser == null)
            {
                return null;
            }

            // Actualizar los campos del usuario
            existingUser.Rut = updateUserDto.Rut;
            existingUser.Name = updateUserDto.Name;
            existingUser.Email = updateUserDto.Email;
            existingUser.Gender = updateUserDto.Gender;
            existingUser.Birthdate = updateUserDto.Birthdate;

            // Guardar los cambios en la base de datos
            await _dataContext.SaveChangesAsync();

            return existingUser;
        }
        /*
        public async Task<User?> Delete(int id)
        {
            var userModel = _dataContext.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (userModel == null)
            {
                return null;
            }

            await _dataContext.Users.Remove(userModel);
            await _dataContext.SaveChangesAsync();
            return userModel;
        }
        */
    }
}