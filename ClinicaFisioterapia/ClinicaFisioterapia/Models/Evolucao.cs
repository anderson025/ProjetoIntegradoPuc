using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Models {
	public class Evolucao {

		[Key]
		public Int32 Id { get; set; }	
		[JsonIgnore]
		public virtual Sessao Sessao { get; set; }
		[Required]
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
