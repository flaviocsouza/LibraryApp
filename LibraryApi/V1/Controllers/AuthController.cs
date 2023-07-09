using LibraryApi.Configuration;
using LibraryApi.Controllers;
using LibraryApi.DTO;
using LibraryBusiness.Interface.Notificator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryApi.V1.Controllers
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("api/{Version:apiVersion}/User")]
    public class AuthController : MainController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JWTSettings _jwtSettings;

        public AuthController(INotificator notificator,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<JWTSettings> jwtSettings) : base(notificator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO registerUser)
        {
            if (!ModelState.IsValid) return CustomResult(ModelState);

            IdentityUser user = new IdentityUser
            {
                Email = registerUser.email,
                UserName = registerUser.email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResult(await GenerateJWT(registerUser.email));
            }

            foreach (var error in result.Errors)
            {
                Notificate(error.Description);
            }
            return CustomResult(registerUser);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(SignInUserDTO userDTO)
        {
            if (!ModelState.IsValid) return CustomResult(ModelState);
            var result = await _signInManager.PasswordSignInAsync(userDTO.email, userDTO.password, false, true);
            if (result.Succeeded) return CustomResult(await GenerateJWT(userDTO.email));
            if (result.IsLockedOut)
            {
                Notificate("User is Blocked");
                return CustomResult(userDTO);
            }

            Notificate("e-Mail or Password is Incorrect");
            return CustomResult(userDTO);
        }

        private async Task<ResponseAuthenticationDTO> GenerateJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await GenerateUserClaims(user);

            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var token = jwtHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.HoursToExpire),
                Subject = claims,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var writeToken = jwtHandler.WriteToken(token);
            var claimList = claims.Claims.Select(c => new ClaimDTO { Type = c.Type, Value = c.Value });

            return new ResponseAuthenticationDTO
            {
                JWTValue = writeToken,
                UserInfo = new UserInfoDTO
                {
                    EMail = user.Email,
                    Claims = claimList
                }
            };

        }

        private async Task<ClaimsIdentity> GenerateUserClaims(IdentityUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);

            foreach (var role in await _userManager.GetRolesAsync(user))
                userClaims.Add(new Claim(ClaimTypes.Role, role));

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(), ClaimValueTypes.Integer64));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaims(userClaims);
            return claimsIdentity;

        }
    }
}
