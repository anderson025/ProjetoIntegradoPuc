using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Models {
	public class Sessao {
		[Key]
		public Int32 Id { get; set; }

		[JsonIgnore]
		public virtual Avaliacao Avaliacao { get; set; }
		public Int32 IdAvaliacao { get; set; }
		[JsonIgnore]
		public virtual Paciente Paciente { get; set; }
		public Int32 IdPaciente { get; set; }
		public DateTime DataSessao { get; set; }
		[JsonIgnore]
		public virtual Funcionario Funcionario { get; set; }
		public Int32 IdFuncionario { get; set; }

		[JsonIgnore]
		public virtual Evolucao Evolucao { get; set; }
		
	}
}
