using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models {
	public class Funcionario : Pessoa {

		[Required]
		public String Usuario { get; set; }
		[Required]
		public String Senha { get; set; }

	}
	
}
