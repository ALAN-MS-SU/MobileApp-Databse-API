using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace JWT.Models
{
    public class JWTGenerator
    {
        public static string CreateJWT(Token token, string key)
        {
            JwtSecurityTokenHandler handler = new();

            byte[] encoding = System.Text.Encoding.ASCII.GetBytes(key);

            SigningCredentials credentials = new(new SymmetricSecurityKey(encoding), algorithm: SecurityAlgorithms.HmacSha256Signature);



            SecurityTokenDescriptor descriptor = new()
            {
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddHours(4),
                NotBefore = DateTime.Now,
                Subject = CreateClaims(token)
            };
            JwtSecurityToken JWT = handler.CreateJwtSecurityToken(descriptor);

            string StringToken = handler.WriteToken(JWT);

            return StringToken;
        }
        private static ClaimsIdentity CreateClaims(Token token)
        {
            ClaimsIdentity claims = new();
            claims.AddClaim(new Claim(ClaimTypes.Name, token.ID.ToString()));
            foreach (var prop in token.GetType().GetProperties())
            {
                claims.AddClaim(new Claim(prop.Name, prop.GetValue(token)?.ToString() ?? ""));
            }
            //foreach(var role in token.GetType().GetProperties())
            //{
            //    claims.AddClaim(new Claim(ClaimTypes.Role, (role.GetValue(token)??"").ToString() ?? ""));
            //}
            return claims;
        }
    }
}
