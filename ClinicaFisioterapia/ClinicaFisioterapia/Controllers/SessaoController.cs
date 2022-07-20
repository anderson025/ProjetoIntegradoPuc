using ClinicaFisioterapia.Context.Dtos.Sessao;
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
	public class SessaoController : ControllerBase {

		public ISessaoService _sessaoService;

		public SessaoController(ISessaoService sessaoService) {
			_sessaoService = sessaoService;
		}


		[HttpPost(Name ="AdicionaSessao")]
		public async Task<ActionResult> AdicionaSessao([FromBody] SessaoDTO sessaoDto) {

			try {

				//Implementar  se existe avaliacao
				var sessao = await _sessaoService.AdicionaSessao(sessaoDto);

				return CreatedAtRoute(nameof(BuscaSessaoPorId), new { id = sessao.Id }, sessao);
			}
			catch {

				return BadRequest("Erro na requisição");
			}

		}

		[HttpGet("{id:int}", Name = "BuscaSessaoPorId")]
		public async Task<ActionResult<Sessao>> BuscaSessaoPorId(Int32 id) {

			try {
				var sessao = await _sessaoService.BuscaSessaoPorId(id);

				if (sessao == null) {
					return NotFound($"Não existe a sessão com id {id}");
				}
				return Ok(sessao);
			}
			catch {

				return NotFound("Erro na requisição");
			}

		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> ApagaSessao(Int32 id) {

			try {
				var sessao = await _sessaoService.BuscaSessaoPorId(id);

				if (sessao != null) {
					await _sessaoService.ApagaSessao(id);
					return Ok($"Sessão de id {id} foi excluido com sucesso!");
				}
				else {
					return NotFound($"Sessao com id {id} não localizado");
				}

			}
			catch {

				return BadRequest("Requisição inválida!");
			}
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult> AtualizaSessao(int id, [FromBody] Sessao sessao) {

			try {
				if (sessao.Id == id) {
					await _sessaoService.AtualizaSessao(sessao);
					return Ok($"Sessao com id= {id} foi atualizado com sucesso");
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
		public async Task<ActionResult<IAsyncEnumerable<Sessao>>> BuscaSessoes() {

			try {
				var sessao = await _sessaoService.BuscaTodasSessoes();
				return Ok(sessao);
			}
			catch {

				return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter Sessão");
			}
		}
	}
}