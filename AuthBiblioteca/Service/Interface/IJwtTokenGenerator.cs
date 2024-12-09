using AuthBiblioteca.Models;

namespace AuthBiblioteca.Service.Interface
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UsuarioEntity user, IEnumerable<string> roles);
    }
}
