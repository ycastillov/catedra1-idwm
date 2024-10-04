using System.ComponentModel.DataAnnotations;

namespace Catedra1_idwm.src.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Rut { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        
        // Relación entre User y Gender
        public int GenderId { get; set; }
        public Gender Gender { get; set; } = null!;
    }
}