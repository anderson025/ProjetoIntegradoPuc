using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Context.Dtos.Sessao;
using System;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Context.Dtos.Evolucao {
	public class EvolucaoDTO {

		[JsonIgnore]
		public virtual SessaoDTO Sessao { get; set; }
		public Int32 IdSessao { get; set; }

		public virtual PacienteDTO Paciente { get; set; }
		public DateTime DataSessao { get; set; }
		public virtual FuncionarioDTO Funcionario { get; set; }
		public String Observacao { get; set; }

		public Status Status { get; set; }
		public DateTime DataEvolucao { get; set; }
	}

	public enum Status {
		pendente = 0,
		concluido = 1
	}
}
