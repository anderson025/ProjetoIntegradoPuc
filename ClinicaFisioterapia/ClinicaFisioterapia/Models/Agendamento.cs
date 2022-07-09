using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Models {
	public class Agendamento {

		[Key]		
		public int IdAgendamento { get; set; }

		[JsonIgnore]
		public virtual Funcionario Funcionario { get; set; }
		[Required]
		public int IdFuncionario { get; set; }

		[JsonIgnore]
		public virtual Paciente Paciente { get; set; }
		[Required]
		public int IdPaciente { get; set; }
		[Required]
		public DateTime DataAgendamento { get; set; }
		
		
	}

	
}
