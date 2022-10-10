using ClinicaFisioterapia.Context.Dtos.Agendamento;
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
	public class AgendamentoController : Controller {

		public IAgendamentoService _agendamentoService;

		public AgendamentoController(IAgendamentoService agendamentoService) {
			_agendamentoService = agendamentoService;
		}


		[HttpPost]
		public async Task<ActionResult> AdicionaAgendamento([FromBody] AgendamentoDTO agendamentoDto) {

			try {

				var pacienteMarcado = await _agendamentoService.BuscaPorIdPaciente(agendamentoDto.IdPaciente);

				if (pacienteMarcado.Count == 0) {

					Agendamento agendamento = await _agendamentoService.AdicionaAgendamento(agendamentoDto);

					if (agendamento == null) {
						return BadRequest("Data não disponível");
					}
					return CreatedAtRoute(nameof(BuscaAgendamentoPorId), new { id = agendamento.IdAgendamento }, agendamento);

				}
				else {

					return BadRequest("Paciente já possui agendamento");
				}


			}
			catch {

				return BadRequest("Erro na requisição");
			}

		}

		[HttpGet("{id:int}", Name = "BuscaAgendamentoPorId")]
		public async Task<ActionResult<AgendamentoDTO>> BuscaAgendamentoPorId(int id) {

			try {
				var agendamento = await _agendamentoService.BuscaAgendamentoPorId(id);

				if (agendamento == null) {
					return NotFound($"Não existe o funcionário com id {id}");
				}
				return Ok(agendamento);
			}
			catch {

				return NotFound("Erro na requisição");
			}
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IAsyncEnumerable<ExibeAgendamentoDTO>>> BuscaTodosAgendamentos() {

			try {
				var agendamento = await _agendamentoService.BuscaTodosAgendamentos();
				return Ok(agendamento);
			}
			catch {

				return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter Agendamento");
			}
		}

		[HttpGet("BuscaTodosPendenteAgendamentos")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IAsyncEnumerable<ExibeAgendamentoDTO>>> BuscaTodosPendenteAgendamentos() {

			try {
				var agendamento = await _agendamentoService.BuscaTodasPendentesAgendamento();
				return Ok(agendamento);
			}
			catch {

				return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter Agendamento");
			}
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> ApagaAgendamento(Int32 id) {

			try {

				await _agendamentoService.ApagaAgendamento(id);
				return Ok($"Agendamento de id {id} foi excluido com sucesso!");

			}
			catch {

				return BadRequest("Requisição inválida!");
			}
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult> AtualizaAgendamento(int id, [FromBody] Agendamento agendamento) {

			try {
				if (agendamento.IdAgendamento == id) {
					await _agendamentoService.AtualizaAgendamento(agendamento);
					return Ok($"Agendamento com id= {id} foi atualizado com sucesso");
				}
				else {
					return BadRequest("Erro na atualização");
				}
			}
			catch {

				return BadRequest("Erro na requisição");
			}
		}


		[HttpGet("BuscaAgendamentoPorData")]
		public async Task<ActionResult<IAsyncEnumerable<AgendamentoDTO>>> BuscaAgendamentoPorData([FromQuery] string data) {

			try {
				var agendamento = await _agendamentoService.BuscaPorData(data);

				if (agendamento == null) {
					return NotFound($"Não existe o agendamento para a data {data}");
				}
				return Ok(agendamento);
			}
			catch {

				return NotFound("Erro na requisição");
			}
		}
	}
}
