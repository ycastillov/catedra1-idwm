using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1_idwm.src.DTOs;
using Catedra1_idwm.src.Models;

namespace Catedra1_idwm.src.Mappers
{
    public static class UserMapper
    {
        public static CreateUserDto ToUserDto(this User user)
        {
            return new CreateUserDto
            {
                Rut = user.Rut,
                Name = user.Name,
                Email = user.Email,
                Gender = user.Gender,
                Birthdate = user.Birthdate
            };
        }

        public static User ToUserFromUserDto(this CreateUserDto createUserDto)
        {
            return new User
            {
                Rut = createUserDto.Rut,
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Gender = createUserDto.Gender,
                Birthdate = createUserDto.Birthdate
            };
        }   
    }
}