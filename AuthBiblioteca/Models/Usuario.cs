using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthBiblioteca.Models
{
    public class UsuarioEntity : IdentityUser
    {
        [Required]
        public string Name { get; set; }
    }
}
