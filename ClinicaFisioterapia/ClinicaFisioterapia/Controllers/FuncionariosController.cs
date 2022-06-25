using AutoMapper;
using ClinicaFisioterapia.Context.Dtos;
using ClinicaFisioterapia.Models;
using ClinicaFisioterapia.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaFisioterapia.Controllers {

	[Route("api/[controller]")]
	[ApiController]	
	public class FuncionariosController : ControllerBase {


		private IFuncionarioService _funcionarioService;
		private IMapper _mapper;

		public FuncionariosController(IFuncionarioService funcionarioService, IMapper mapper) { 
			_funcionarioService = funcionarioService;
			_mapper = mapper;
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
		public async Task<ActionResult> AdicionaFuncionario([FromBody] FuncionarioDTO funcionarioDto) {

			Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);

			try {
				await _funcionarioService.AdicionaFuncionario(funcionario);

				return CreatedAtRoute(nameof(BuscaFuncionarioPorId), new { id = funcionario.Id}, funcionario);
			}
			catch {

				return BadRequest("Erro na requisição");
			}

		}

		
		[HttpPut("{id:int}")]
		public async Task<ActionResult> AtualizaFuncionario(int id, [FromBody] Funcionario funcionario) {

			try {
				if (funcionario.Id == id) {
					await _funcionarioService.AtualizaFuncionario(funcionario);
					return Ok($"Funcionario com id= {id} foi atualizado com sucesso");
				}
				else {
					return BadRequest("Erro na atualização");
				}
			}
			catch {

				return BadRequest("Erro na requisição");
			}
		}

		
		[HttpDelete("{id}")]
		public async Task<ActionResult> ApagaFuncionario(int id) {

			try {
				var funcionario = await _funcionarioService.BuscaFuncionarioPorId(id);

				if (funcionario != null) {
					await _funcionarioService.ApagaFuncionario(funcionario);
					return Ok($"Funcionario de id {id} foi excluido com sucesso!");
				}
				else {
					return NotFound($"Funcionario com id {id} não localizado");
				}
				 
			}
			catch  {

				return BadRequest("Requisição inválida!");
			}
		}
	}
}
