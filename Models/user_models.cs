using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("users")]
    public class User
    {
         public int Id { get; set; }
         public required string Name { get; set; }
         public required string Surname { get; set; }
         public string? Email { get; set; }
    }
}