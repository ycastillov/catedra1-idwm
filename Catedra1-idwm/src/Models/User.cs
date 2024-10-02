using System.ComponentModel.DataAnnotations;

namespace Catedra1_idwm.src.Models
{
    public class User
    {
        [Key]
        public string rut { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [RegularExpression(@"masculino|femenino|otro|prefiero no")]
        public string Gender { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
    }
}