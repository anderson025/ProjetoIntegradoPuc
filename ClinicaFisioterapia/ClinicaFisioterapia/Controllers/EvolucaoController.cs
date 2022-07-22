using ClinicaFisioterapia.Context.Dtos.Evolucao;
using ClinicaFisioterapia.Models;
using ClinicaFisioterapia.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	public class EvolucaoController : ControllerBase {

		private IEvolucaoService _evolucaoService;

		public EvolucaoController(IEvolucaoService evolucaoService) {
			_evolucaoService = evolucaoService;
		}

		[HttpPost]
		public async Task<ActionResult> AdicionaEvolucao([FromBody] Evolucao evolucaoDto) {

			try {
				var evolucao = await _evolucaoService.AdicionaEvolucao(evolucaoDto);

				return CreatedAtRoute(nameof(BuscaEvolucaoPorId), new { id = evolucao.Id }, evolucao);
			}
			catch {

				return BadRequest("Erro na requisição");
			}

		}

		[HttpGet("{id:int}", Name = "BuscaEvolucaoPorId")]
		public async Task<ActionResult<Evolucao>> BuscaEvolucaoPorId(Int32 id) {

			try {
				var evolucao = await _evolucaoService.BuscaEvolucaoPorId(id);

				if (evolucao == null) {
					return NotFound($"Não existe o evolucao com id {id}");
				}
				return Ok(evolucao);
			}
			catch {

				return NotFound("Erro na requisição");
			}

		}

		//[HttpDelete("{id}")]
		//public async Task<ActionResult> ApagaEvolucao(Int32 id) {

		//	try {

		//		await _evolucaoService.ApagaEvolucao(id);
		//		return Ok($"Evolucao de id {id} foi excluido com sucesso!");

		//	}
		//	catch {

		//		return BadRequest("Requisição inválida!");
		//	}
		//}

		//[HttpPut("{id:int}")]
		//public async Task<ActionResult> AtualizaEvolucao(int id, [FromBody] Evolucao evolucao) {

		//	try {
		//		if (evolucao.Id == id) {
		//			await _evolucaoService.AtualizaEvolucao(evolucao);
		//			return Ok($"Evolucao com id= {id} foi atualizado com sucesso");
		//		}
		//		else {
		//			return BadRequest("Erro na atualização");
		//		}
		//	}
		//	catch {

		//		return BadRequest("Erro na requisição");
		//	}
		//}
	}
}
