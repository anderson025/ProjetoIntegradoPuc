using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Models {
	public class Paciente : Pessoa {

		[JsonIgnore]
		public virtual Avaliacao Avaliacao { get; set; }

		[JsonIgnore]
		public virtual List<Sessao> Sessoes { get; set; }		

		//[JsonIgnore]
		//public virtual Evolucao Evolucao { get; set; }

		//public Int32 IdEvolucaoPaciente { get; set; }

	}
}
