using ClinicaFisioterapia.Models;
using ClinicaFisioterapia.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaFisioterapia.Controllers {

	[Route("[controller]")]
	[ApiController]
	public class FuncionariosController : ControllerBase {


		private IFuncionarioService _funcionarioService;

		public FuncionariosController(IFuncionarioService funcionarioService) { 
			_funcionarioService = funcionarioService;
		}

		
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IAsyncEnumerable<Funcionario>>> BuscaFuncionario() {

			try {
				var funcionarios = await _funcionarioService.BuscaFuncionario();
				return Ok(funcionarios);
			}
			catch  {

				return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter Funcionarios");
			}
		}

		[HttpGet("BuscaFuncionarioPorNome")]
		public async Task<ActionResult<IAsyncEnumerable<Funcionario>>> BuscaFuncionarioPorNome([FromQuery]string nome) {

			try {
				var funcionarios = await _funcionarioService.BuscaPorNome(nome);
				if (funcionarios.Count() == 0) {
					return NotFound($"Não existe o funcionário {nome}");
				}
				return Ok(funcionarios);
			}
			catch {

				return BadRequest("Requisição inválida");
			}
		}

		
		[HttpGet("{id:int}", Name = "BuscaFuncionarioPorId")]
		public async Task<ActionResult<Funcionario>> BuscaFuncionarioPorId(int id) {

			try {
				var funcionario = await _funcionarioService.BuscaFuncionarioPorId(id);

				if (funcionario == null) {
					return NotFound($"Não existe o funcionário com id {id}");
				}
				return Ok(funcionario);
			}
			catch  {

				return NotFound("Erro na requisição");
			}
			 
		}

		
		[HttpPost]
		public async Task<ActionResult> AdicionaFuncionario([FromBody] Funcionario func) {

			try {
				await _funcionarioService.AdicionaFuncionario(func);

				return CreatedAtRoute(nameof(BuscaFuncionarioPorId), new { id = func.Id}, func);
			}
			catch {

				return BadRequest("Erro na requisição");
			}

		}

		
		[HttpPut("{id}")]
		public void AtualizaFuncionario(int id, [FromBody] string value) {
		}

		
		[HttpDelete("{id}")]
		public void ApagaFuncionario(int id) {
		}
	}
}
