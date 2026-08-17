using Microsoft.IdentityModel.Tokens;
using Proyecto_VETERINARIA_BD.DTOs;
using Proyecto_VETERINARIA_BD.Interfaces;
using Proyecto_VETERINARIA_BD.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proyecto_VETERINARIA_BD.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<UsuarioCreadoDto?> RegistrarAsync(RegistroDto dto)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Contrasena);
            return await _context.sp_Usuario_Insertar(dto.NombreUsuario, dto.Correo, hash, dto.Rol);
        }

        public async Task<TokenResponseDto?> LoginAsync(LoginDto dto)
        {
            var usuario = await _context.sp_Usuario_ObtenerPorNombre(dto.NombreUsuario);

            if (usuario == null || usuario.Estado != "Activo")
                return null;

            if (!BCrypt.Net.BCrypt.Verify(dto.Contrasena, usuario.ContrasenaHash))
                return null;

            var token = GenerarToken(usuario);
            var expira = DateTime.UtcNow.AddMinutes(double.Parse(_config["Jwt:ExpireMinutes"]!));

            return new TokenResponseDto
            {
                Token = token,
                NombreUsuario = usuario.NombreUsuario,
                Rol = usuario.Rol,
                Expira = expira
            };
        }

        private string GenerarToken(UsuarioDto usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Role, usuario.Rol),
                new Claim("IdUsuario", usuario.IdUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_config["Jwt:ExpireMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}