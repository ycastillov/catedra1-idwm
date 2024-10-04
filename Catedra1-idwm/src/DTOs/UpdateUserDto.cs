using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Catedra1_idwm.src.Validations;

namespace Catedra1_idwm.src.DTOs
{
    public class UpdateUserDto
    {
        public string Rut { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [RegularExpression(@"1|2|3|4")]
        public int GenderId { get; set; }

        [DataType(DataType.Date)]
        [BirthdateValidation(ErrorMessage = "La fecha de nacimiento debe ser menor a la fecha actual")]
        public DateTime Birthdate { get; set; }
    }
}