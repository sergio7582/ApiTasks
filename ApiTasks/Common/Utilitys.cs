using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ApiTasks.DataBase;
using ApiTasks.DTOs;
using ApiTasks.DTOs.Access;

namespace ApiTasks.Common
{
    public class Utilitys
    {
        private readonly IConfiguration _configuration;
        public Utilitys(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string EncrypthSHA256(string value)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public string GenerateToken(UsuarioView user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(ClaimTypes.NameIdentifier, user.Username!)
                ]),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Response GetResponse(string Message, bool Success,int StatusCode, Object? Data = null , Object? Errors = null)
        {
            Response response = new Response();
            response.Message = Message;
            response.Success = Success;
            response.Data = Data;
            response.Errors = Errors;
            response.StatusCode = StatusCode;

            return response;


        }
    }
}
