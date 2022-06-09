using ClinicaFisioterapia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaFisioterapia.Controllers {

	[Route("[controller]")]
	[ApiController]
	public class FuncionariosController : ControllerBase {


		private static List<Funcionario> listaFuncinarios = new List<Funcionario>();
		public static int id = 1;

		// GET: api/<FuncionariosController>
		[HttpGet]
		public IEnumerable<Funcionario> BuscaFuncionario() {
			return listaFuncinarios;
		}

		// GET api/<FuncionariosController>/5
		[HttpGet("{id}")]
		public string BuscaFuncionarioPorId(int id) {
			return "value";
		}

		// POST api/<FuncionariosController>
		[HttpPost]
		public void AdicionaFuncionario([FromBody] Funcionario value) {

			listaFuncinarios.Add(value);
			
		}

		// PUT api/<FuncionariosController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value) {
		}

		// DELETE api/<FuncionariosController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
