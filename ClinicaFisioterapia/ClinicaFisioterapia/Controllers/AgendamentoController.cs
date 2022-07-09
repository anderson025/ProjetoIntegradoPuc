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

		public IAgendamentoService _agendamentoService { get; set; }

		public AgendamentoController(IAgendamentoService agendamentoService) {
			_agendamentoService = agendamentoService;
		}


		[HttpPost]
		public async Task<ActionResult> AdicionaFuncionario([FromBody] AgendamentoDTO agendamentoDto) {

			try {

				
				Agendamento agendamento = await _agendamentoService.AdicionaAgendamento(agendamentoDto);
				if (agendamento == null) {
					return BadRequest("Data não disponível");
				}
				return CreatedAtRoute(nameof(BuscaAgendamentoPorId), new { id = agendamento.IdAgendamento }, agendamento);
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
	}
}
