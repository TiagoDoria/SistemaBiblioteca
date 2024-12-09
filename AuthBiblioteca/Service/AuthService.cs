using AuthBiblioteca.Data;
using AuthBiblioteca.DTOs;
using AuthBiblioteca.Models;
using AuthBiblioteca.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System.Net;

namespace AuthBiblioteca.Service
{
    public class AuthService : IAuthService
    {
        private readonly AuthContext _db;
        private readonly UserManager<UsuarioEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AuthContext db, UserManager<UsuarioEntity> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _db.Usuarios.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if (user == null || !isValid)
            {
                return new LoginResponseDTO() { User = null, Token = "" };
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            UserDTO userDTO = new()
            {
                Id = Guid.Parse(user.Id),
                Email = user.Email,
                Name = user.Name
            };

            LoginResponseDTO responseDTO = new LoginResponseDTO()
            {
                User = userDTO,
                Token = token
            };

            return responseDTO;
        }

        public async Task<RespostaDTO<UserDTO>> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            RespostaDTO<UserDTO> response = new();

            UsuarioEntity user = new()
            {
                UserName = registrationRequestDTO.Email,
                Email = registrationRequestDTO.Email,
                NormalizedEmail = registrationRequestDTO.Email.ToUpper(),
                Name = registrationRequestDTO.Name
            };

            try
            {
                // Criação do usuário com senha
                var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _db.Usuarios.FirstOrDefault(u => u.UserName == registrationRequestDTO.Email);

                    if (userToReturn == null)
                    {
                        response.IsSuccess = false;
                        response.Message = "Usuário criado, mas não encontrado no banco de dados.";
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        return response;
                    }

                    // Retornando o usuário criado
                    UserDTO userDTO = new()
                    {
                        Id = Guid.Parse(userToReturn.Id),
                        Email = userToReturn.Email,
                        Name = userToReturn.Name
                    };

                    response.IsSuccess = true;
                    response.Result = userDTO;
                    response.Message = "Usuário registrado com sucesso!";
                    response.StatusCode = HttpStatusCode.OK;

                    return response;
                }
                else
                {
                    // Captura o primeiro erro retornado pelo Identity
                    response.IsSuccess = false;
                    response.Message = result.Errors.FirstOrDefault()?.Description ?? "Erro desconhecido ao criar usuário.";
                    response.StatusCode = HttpStatusCode.BadRequest;

                    return response;
                }
            }
            catch (Exception ex)
            {
                // Tratamento de exceção inesperada
                response.IsSuccess = false;
                response.Message = $"Ocorreu um erro ao registrar o usuário: {ex.Message}";
                response.StatusCode = HttpStatusCode.InternalServerError;

                Log.Error(ex, "Erro durante o registro de usuário.");
                return response;
            }
        }
    }
}
