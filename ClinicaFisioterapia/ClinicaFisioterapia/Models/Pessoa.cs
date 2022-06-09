using System;

namespace ClinicaFisioterapia.Models {
	public class Pessoa {
		
		public int Id { get; set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public int Idade { get; set; }
	}
}

