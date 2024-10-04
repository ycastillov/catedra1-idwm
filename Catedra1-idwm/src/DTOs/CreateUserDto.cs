using System.ComponentModel.DataAnnotations;
using Catedra1_idwm.src.Validations;

namespace Catedra1_idwm.src.DTOs
{
    public class CreateUserDto
    {
        public required string Rut { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public required string Name { get; set; } = string.Empty;

        [EmailAddress]
        public required string Email { get; set; } = string.Empty;

        [RegularExpression(@"1|2|3|4")]
        public required int GenderId { get; set; }

        [DataType(DataType.Date)]
        [BirthdateValidation(ErrorMessage = "La fecha de nacimiento debe ser menor a la fecha actual")]
        public required DateTime Birthdate { get; set; }
    }
}