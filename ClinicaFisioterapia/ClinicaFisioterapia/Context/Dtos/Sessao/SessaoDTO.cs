using ClinicaFisioterapia.Context.Dtos.Avaliacao;
using ClinicaFisioterapia.Context.Dtos.Evolucao;
using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using System;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Context.Dtos.Sessao {
	public class SessaoDTO {

		[JsonIgnore]
		public virtual AvaliacaoDTO Avaliacao { get; set; }
		public Int32 IdAvaliacao { get; set; }
		[JsonIgnore]
		public virtual PacienteDTO Paciente { get; set; }
		public Int32 IdPaciente { get; set; }
		public DateTime DataSessao { get; set; }
		[JsonIgnore]
		public virtual FuncionarioDTO Funcionario { get; set; }
		public Int32 IdFuncionario { get; set; }

		[JsonIgnore]
		public virtual EvolucaoDTO Evolucao { get; set; }
	}
}
