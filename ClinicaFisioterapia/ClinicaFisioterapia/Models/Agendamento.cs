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

		public String NomeFunciorio { get; set; }

		[JsonIgnore]
		public virtual Paciente Paciente { get; set; }
		[Required]
		public int IdPaciente { get; set; }

		public String NomePaciente { get; set; }

		[Required]
		public DateTime DataAgendamento { get; set; }

		public int PendenteAvaliacao { get; set; }

		//[JsonIgnore]
		//public virtual Avaliacao Avaliacao { get; set; }


	}

	
}
