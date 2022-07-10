﻿using ClinicaFisioterapia.Context.Dtos.Avaliacao;
using ClinicaFisioterapia.Models;
using ClinicaFisioterapia.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class AvaliacaoController : ControllerBase {

		public IAvaliacaoService _avaliacaoService;

		public AvaliacaoController(IAvaliacaoService avaliacaoService) {
			_avaliacaoService = avaliacaoService;
		}

		[HttpPost]
		public async Task<ActionResult> AdicionaAvaliacao([FromBody] AvaliacaoDTO avaliacaoDto) {

			try {

				Avaliacao avaliacao = await _avaliacaoService.AdicionaAvaliacao(avaliacaoDto);
				//if (avaliacao == null) {
				//	return BadRequest("Data não disponível");
				//}
				return CreatedAtRoute(nameof(BuscaAvaliacaoPorId), new { id = avaliacao.Id }, avaliacao);
			}
			catch {

				return BadRequest("Erro na requisição");
			}

		}


		[HttpGet("{id:int}", Name = "BuscaAvaliacaoPorId")]
		public async Task<ActionResult<Funcionario>> BuscaAvaliacaoPorId(Int32 id) {

			try {
				var funcionario = await _avaliacaoService.BuscaAvaliacaoPorId(id);

				if (funcionario == null) {
					return NotFound($"Não existe o avaliacao com id {id}");
				}
				return Ok(funcionario);
			}
			catch {

				return NotFound("Erro na requisição");
			}

		}
	}
}