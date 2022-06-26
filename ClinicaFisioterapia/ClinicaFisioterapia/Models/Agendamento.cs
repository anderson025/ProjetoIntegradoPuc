using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models {
	public class Agendamento {

		[Key]
		public int IdAgendamento { get; set; }
		public Funcionario Funcionario { get; set; }
		public Paciente Paciente { get; set; }

		public DateTime DataInicio { get; set; }
		public DateTime DataFim { get; set; }

		public virtual ICollection<HorarioAgendamento> Horarios { get; set; }
		
		public Int32 IdHorario { get; set; }
	}

	
}
