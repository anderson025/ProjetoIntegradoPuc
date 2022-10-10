using ClinicaFisioterapia.Models;
using ClinicaFisioterapia.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	public class ContaController : ControllerBase {

		private readonly IConfiguration _configuration;
		private readonly IAuthenticate _authenticate;

		public ContaController(IConfiguration configuration, IAuthenticate authenticate) {

			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			_authenticate = authenticate ?? throw new ArgumentNullException(nameof(authenticate));
		}

		[HttpPost("CriarUsuario")]
		public async Task<ActionResult<UserToken>> CriarUsuario([FromBody] RegisterModel model) {

			if (model.Password != model.ConfirmPassword) {
				ModelState.AddModelError("ConfirmPassword", "As senhas não conferem");
				return BadRequest(ModelState);
			}

			var result = await _authenticate.RegisterUser(model.Email, model.Password);

			if (result) {
				return Ok($"Usuário {model.Email} criado com sucesso!");


			}
			else {
				ModelState.AddModelError("CreateUser", "Registro inválido");
				return BadRequest(ModelState);
			}
		}

		[HttpPost("LoginUser")]
		public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo) {

			var result = await _authenticate.Authenticate(userInfo.Email, userInfo.Password);

			if (result) {
				return GenarateToken(userInfo);


			}
			else {
				ModelState.AddModelError("LoginUser", "Login inválido");
				return BadRequest(ModelState);
			}
		}

		private ActionResult<UserToken> GenarateToken(LoginModel userInfo) {

			var claims = new[] {
				new Claim("email", userInfo.Email),
				new Claim("meuToken", "Token projeto"),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));

			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expiration = DateTime.UtcNow.AddMinutes(20);

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: expiration,
				signingCredentials: creds);

			return new UserToken() {
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				Expiration = expiration,
			};




		}
	}
}
