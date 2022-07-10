using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models {
	public class Evolucao {

		[Key]
		public Int32 Id { get; set; }
		public virtual Sessao Sessao { get; set; }
		public Int32 IdSessao { get; set; }

		public virtual Paciente Paciente { get; set; }
		public DateTime DataSessao { get; set; }
		public virtual Funcionario Funcionario { get; set; }
		public String Observacao { get; set; }

		public Status Status { get; set; }
		public DateTime DataEvolucao { get; set; }
	}

	public enum Status {
		pendente = 0,
		concluido = 1
	}
}
