using AuthBiblioteca.DTOs;

namespace AuthBiblioteca.Service.Interface
{
    public interface IAuthService
    {
        Task<RespostaDTO<UserDTO>> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<bool> AssignRole(string email, string roleName);
    }
}
