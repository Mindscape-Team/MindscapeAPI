using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MindscapeAPI.Data;
using MindscapeAPI.DTOs.Auth;
using MindscapeAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MindscapeAPI.Repository.Auth
{
    public class AuthRepo : IAuthRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWT _jwt;

        public AuthRepo(UserManager<ApplicationUser> userManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
        }

        public async Task<AuthDTO> LoginAsync(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return new AuthDTO { Message = "Invalid email or password" };

            var jwtSecurityToken = await CreateJWTToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            return new AuthDTO
            {
                isValid = true,
                UserName = user.Email,
                Email = user.Email,
                Roles = roles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                ExpireOn = jwtSecurityToken.ValidTo
            };
        }

        public async Task<AuthDTO> RegisterAsync(RegisterDTO dto)
        {
            var existingEmail = await _userManager.FindByEmailAsync(dto.Email);
            if (existingEmail != null)
                return new AuthDTO { Message = "Email already exists!" };

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                FullName = dto.FullName,
                Email = dto.Email,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}, ";
                }

                return new AuthDTO { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken = await CreateJWTToken(user);

            return new AuthDTO
            {
                isValid = true,
                UserName = user.Email,
                Email = user.Email,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                ExpireOn = jwtSecurityToken.ValidTo
            };
        }

        public async Task<JwtSecurityToken> CreateJWTToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in userRoles)
                roleClaims.Add(new Claim("role", role));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.GivenName, user.FullName.Trim()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }.Union(userClaims).Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SigningKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials
            );

            return jwtSecurityToken;
        }
    }
}
