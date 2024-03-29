﻿using AutoMapper;
using ClinicaFisioterapia.Context.Dtos;
using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Models;
using ClinicaFisioterapia.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ClinicaFisioterapia.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
	public class FuncionariosController : ControllerBase {


		private IFuncionarioService _funcionarioService;


		public FuncionariosController(IFuncionarioService funcionarioService) {
			_funcionarioService = funcionarioService;
		}


		[HttpPost]
		public async Task<ActionResult> AdicionaFuncionario([FromBody] FuncionarioDTO funcionarioDto) {

			try {
				ExibeFuncionarioDTO funcionario = await _funcionarioService.AdicionaFuncionario(funcionarioDto);

				return CreatedAtRoute(nameof(BuscaFuncionarioPorId), new { id = funcionario.Id }, funcionario);
			}
			catch {

				return BadRequest("Erro na requisição");
			}

		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> ApagaFuncionario(Int32 id) {

			try {
				//var funcionario = await _funcionarioService.BuscaFuncionarioPorId(id);
				await _funcionarioService.ApagaFuncionario(id);
				return Ok($"Funcionario de id {id} foi excluido com sucesso!");
				//if (funcionario != null) {
				//}
				//else {
				//	return NotFound($"Funcionario com id {id} não localizado");
				//}

			}
			catch {

				return BadRequest("Requisição inválida!");
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

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IAsyncEnumerable<ExibeFuncionarioDTO>>> BuscaFuncionario() {

			try {
				var funcionarios = await _funcionarioService.BuscaFuncionario();
				return Ok(funcionarios);
			}
			catch {

				return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter Funcionarios");
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
			catch {

				return NotFound("Erro na requisição");
			}

		}

		[HttpGet("BuscaFuncionarioPorNome")]
		public async Task<ActionResult<IAsyncEnumerable<ExibeFuncionarioDTO>>> BuscaFuncionarioPorNome([FromQuery] string nome) {

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

	}
}
