using System;

namespace ClinicaFisioterapia.Models {
	public class HorarioAgendamento {

		public int Id { get; set; }
		public DiaSemana DiaSemana { get; set; }
		public TimeSpan HorarioInicial { get; set; }
		public TimeSpan HorarioFinal { get; set; }
		public virtual Agendamento Agendamento { get; set; }
	}

	public enum DiaSemana {
		Domingo,
		Segunda,
		Terca,
		Quarta,
		Quinta,
		Sexta,
		Sabado
	}
}
