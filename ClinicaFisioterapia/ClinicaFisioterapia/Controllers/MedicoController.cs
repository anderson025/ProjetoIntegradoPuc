using ClinicaFisioterapia.Context.Dtos.Medico;
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
	public class MedicoController : ControllerBase {

		public IMedicoService _medicoService;

		public MedicoController(IMedicoService medicoService) {
			_medicoService = medicoService;
		}

		[HttpPost]
		public async Task<ActionResult> AdicionaMedico([FromBody] MedicoDTO medicoDto) {

			try {
				var medico = await _medicoService.AdicionaMedico(medicoDto);

				return CreatedAtRoute(nameof(BuscaMedicoPorId), new { id = medico.Id }, medico);
			}
			catch {

				return BadRequest("Erro na requisição");
			}

		}

		[HttpGet("{id:int}", Name = "BuscaMedicoPorId")]
		public async Task<ActionResult<Medico>> BuscaMedicoPorId(Int32 id) {

			try {
				var medico = await _medicoService.BuscaMedicoPorId(id);

				if (medico == null) {
					return NotFound($"Não existe o Médico com id {id}");
				}
				return Ok(medico);
			}
			catch {

				return NotFound("Erro na requisição");
			}

		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> ApagaMedico(Int32 id) {

			try {
				var medico = await _medicoService.BuscaMedicoPorId(id);

				if (medico != null) {
					await _medicoService.ApagaMedico(id);
					return Ok($"Médico de id {id} foi excluido com sucesso!");
				}
				else {
					return NotFound($"Médico com id {id} não localizado");
				}

			}
			catch {

				return BadRequest("Requisição inválida!");
			}
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult> AtualizaMedico(int id, [FromBody] Medico medico) {

			try {
				if (medico.Id == id) {
					await _medicoService.AtualizaMedico(medico);
					return Ok($"Médico com id= {id} foi atualizado com sucesso");
				}
				else {
					return BadRequest("Erro na atualização");
				}
			}
			catch {

				return BadRequest("Erro na requisição");
			}
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IAsyncEnumerable<Medico>>> BuscaMedicos() {

			try {
				var medicos = await _medicoService.BuscaTodosMedicos();
				return Ok(medicos);
			}
			catch {

				return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter Médicos");
			}
		}
	}
}
