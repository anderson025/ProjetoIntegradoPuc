using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models {
	public class Evolucao {

		[Key]
		public Int32 Id { get; set; }		
		public virtual Sessao Sessao { get; set; }
		public Int32 IdSessao { get; set; }		
		public String Observacao { get; set; }

		public Status Status { get; set; }
		public DateTime DataEvolucao { get; set; }
	}

	public enum Status {
		pendente = 0,
		concluido = 1
	}
}
