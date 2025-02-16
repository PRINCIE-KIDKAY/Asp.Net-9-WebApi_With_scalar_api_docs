using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace api.Dtos.User;

 public class UserDto
    {


        public int Id { get; set; }

        [Required]
         public required string Name { get; set; }
         
         [Required]
         public required string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
