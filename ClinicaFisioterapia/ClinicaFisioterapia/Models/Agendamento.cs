using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models {
	public class Agendamento {

		[Key]
		public int IdAgendamento { get; set; }
		public Funcionario Funcionario { get; set; }
		public Paciente Paciente { get; set; }

		public DateTime DataAgendamento { get; set; }

		public TimeSpan HorarioAgendamento { get; set; }
	}
}
