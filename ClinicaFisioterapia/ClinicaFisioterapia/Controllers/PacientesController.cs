using AutoMapper;
using ClinicaFisioterapia.Context.Dtos;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Models;
using ClinicaFisioterapia.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	public class PacientesController : Controller {

		private IPacienteService _pacienteService;
		private IMapper _mapper;

		public PacientesController(IPacienteService pacienteService, IMapper mapper) {
			_pacienteService = pacienteService;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IAsyncEnumerable<Paciente>>> BuscaPacientes() {

			try {
				var pacientes = await _pacienteService.BuscaPacientes();
				return Ok(pacientes);
			}
			catch {

				return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter Funcionarios");
			}
		}

		[HttpGet("BuscaPacientePorNome")]
		public async Task<ActionResult<IAsyncEnumerable<Paciente>>> BuscaPacientePorNome([FromQuery] string nome) {

			try {
				var paciente = await _pacienteService.BuscaPorNome(nome);
				if (paciente == null) {
					return NotFound($"Não existe o paciente {nome}");
				}
				return Ok(paciente);
			}
			catch {

				return BadRequest("Requisição inválida");
			}
		}

		[HttpGet("{id:int}", Name = "BuscaPacientePorId")]
		public async Task<ActionResult<Paciente>> BuscaPacientePorId(Int32 id) {

			try {
				var paciente = await _pacienteService.BuscaPacientePorId(id);

				if (paciente == null) {
					return NotFound($"Não existe o Paciente com id {id}");
				}
				return Ok(paciente);
			}
			catch {

				return NotFound("Erro na requisição");
			}

		}


		[HttpPost(Name ="AdicionaPaciente")]
		public async Task<ActionResult> AdicionaPaciente([FromBody] PacienteDTO pacienteDTO) {

			Paciente paciente = _mapper.Map<Paciente>(pacienteDTO);
			try {
				await _pacienteService.AdicionaPaciente(paciente);

				return CreatedAtRoute(nameof(BuscaPacientePorId), new { id = paciente.Id }, paciente);
			}
			catch {

				return BadRequest("Erro na requisição");
			}

		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult> AtualizaPaciente(int id, [FromBody] Paciente paciente) {

			try {
				if (paciente.Id == id) {
					await _pacienteService.AtualizaPaciente(paciente);
					return Ok($"Paciente com id= {id} foi atualizado com sucesso");
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
		public async Task<ActionResult> ApagaPaciente(int id) {

			try {
				var paciente = await _pacienteService.BuscaPacientePorId(id);

				if (paciente != null) {
					await _pacienteService.ApagaPaciente(paciente);
					return Ok($"Paciente de id {id} foi excluido com sucesso!");
				}
				else {
					return NotFound($"Paciente com id {id} não localizado");
				}

			}
			catch {

				return BadRequest("Requisição inválida!");
			}
		}
	}
}
