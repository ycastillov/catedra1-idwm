using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra1_idwm.src.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string GenderName { get; set; } = string.Empty;
        
        public ICollection<User> Users = new List<User>();
    }
}