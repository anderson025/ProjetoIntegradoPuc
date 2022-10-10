using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using System;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Context.Dtos.Agendamento {
	public class ExibeAgendamentoDTO {

		public int IdAgendamento { get; set; }	
		
		[JsonIgnore]
		public virtual FuncionarioDTO Funcionario { get ; set; }
		public int IdFuncionario { get; set; }
		public String NomeFunciorio { get; set; }

		[JsonIgnore]
		public virtual PacienteDTO Paciente { get; set; }
		public int IdPaciente { get; set; }
		public String NomePaciente { get; set; }

		public DateTime DataAgendamento { get; set; }
		
	}
}
