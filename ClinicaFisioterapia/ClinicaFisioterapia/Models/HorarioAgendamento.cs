using System;

namespace ClinicaFisioterapia.Models {
	public class HorarioAgendamento {

		public int Id { get; set; }
		public int DiaSemana { get; set; }
		public TimeSpan HorarioInicial { get; set; }
		public TimeSpan HorarioFinal { get; set; }
		public virtual Agendamento idAgendamento { get; set; }
	}
}
