using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Context.Dtos.Agendamento {
	public class AgendamentoDTO {

		[JsonIgnore]
		public virtual FuncionarioDTO Funcionario { get; set; }
		[Required]
		public int IdFuncionario { get; set; }

		[JsonIgnore]
		public virtual PacienteDTO Paciente { get; set; }
		[Required]
		public int IdPaciente { get; set; }
		[Required]
		public DateTime DataAgendamento { get; set; }

	}
}
