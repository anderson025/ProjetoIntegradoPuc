using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Context.Dtos.Sessao;
using ClinicaFisioterapia.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Context.Dtos.Evolucao {
	public class EvolucaoDTO {

		[JsonIgnore]
		public virtual SessaoDTO Sessao { get; set; }
		[Required]
		public Int32 IdSessao { get; set; }
		public String Observacao { get; set; }

		public Status Status { get; set; }
		public DateTime DataEvolucao { get; set; }
	}
	
}
