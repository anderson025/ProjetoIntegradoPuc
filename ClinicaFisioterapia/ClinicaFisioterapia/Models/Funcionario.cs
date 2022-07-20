using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Models {
	public class Funcionario : Pessoa {

		[Required]
		public String Usuario { get; set; }
		[Required]
		public String Senha { get; set; }

		[JsonIgnore]
		public virtual List<Avaliacao> Avaliacoes { get; set; }

		[JsonIgnore]
		public virtual List<Sessao> Sessoes { get; set; }		

		[JsonIgnore]
		public virtual Evolucao Evolucao { get; set; }
		//public Int32 IdEvolucaoFuncionario { get; set; }

	}
	
}
