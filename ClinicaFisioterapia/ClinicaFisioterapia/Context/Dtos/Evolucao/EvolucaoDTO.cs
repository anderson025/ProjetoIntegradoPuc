using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Context.Dtos.Sessao;
using System;

namespace ClinicaFisioterapia.Context.Dtos.Evolucao {
	public class EvolucaoDTO {

		public SessaoDTO Sessao { get; set; }
		public PacienteDTO Paciente { get; set; }
		public DateTime DataSessao { get; set; }
		public FuncionarioDTO Funcionario { get; set; }
		public String Observacao { get; set; }

		public Status Status { get; set; }
		public DateTime DataEvolucao { get; set; }
	}

	public enum Status {
		pendente = 0,
		concluido = 1
	}
}
