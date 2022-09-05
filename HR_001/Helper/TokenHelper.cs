using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace HR_001.Helper
{
    public class TokenHelper
    {
        static HrDbContext context = new HrDbContext();
        public const string Issuer = "http://alicall86.com";
        public const string Audience = "http://alicall86.com";
        public const string Secret = "p0GXO6VuVZLRPef0tyO9jCqK4uZufDa6LP4n8Gj+8hQPB30f94pFiECAnPeMi5N6VT3/uscoGH7+zJrv4AuuPg==";
        public static async Task<string> GenerateAccessToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(Secret);

            var claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            });

            var user = context.Users.SingleOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                var role = context.Roles.SingleOrDefault(r => r.RoleId == user.RoleId);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName.ToString()));
                /*var permission = context.Permissions.SingleOrDefault(p => p.UserId == userId);
                if(permission != null)
                claimsIdentity.AddClaim(new Claim("Permission", permission.PermissionTypeId.ToString()));*/ 

            }

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = Issuer,
                Audience = Audience,
                Expires = DateTime.Now.AddMinutes(15),
                SigningCredentials = signingCredentials,

            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return await System.Threading.Tasks.Task.Run(() => tokenHandler.WriteToken(securityToken));
        }
        public static async Task<string> GenerateRefreshToken()
        {
            var secureRandomBytes = new byte[32];

            using var randomNumberGenerator = RandomNumberGenerator.Create();
            await System.Threading.Tasks.Task.Run(() => randomNumberGenerator.GetBytes(secureRandomBytes));

            var refreshToken = Convert.ToBase64String(secureRandomBytes);
            return refreshToken;
        }
    }
}
