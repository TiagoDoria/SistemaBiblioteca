using AuthBiblioteca.DTOs;

namespace AuthBiblioteca.Service.Interface
{
    public interface IAuthService
    {
        Task<ResponseDTO<UserDTO>> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<ResponseDTO<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO);
        Task<bool> AssignRole(string email, string roleName);
    }
}
