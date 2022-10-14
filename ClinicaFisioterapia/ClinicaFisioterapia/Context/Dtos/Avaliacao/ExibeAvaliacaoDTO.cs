using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Medico;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Context.Dtos.Avaliacao {
	public class ExibeAvaliacaoDTO {

		[Key]
		public Int32 Id { get; set; }
		[JsonIgnore]
		public virtual FuncionarioDTO Funcionario { get; set; }
		public String NomeFuncionario { get; set; }
		[Required]
		public Int32 IdFuncionario { get; set; }
		[JsonIgnore]
		public virtual PacienteDTO Paciente { get; set; }
		public Int32 IdPaciente { get; set; }
		public String NomePaciente { get; set; }

		public DateTime DataAvaliacao { get; set; }

		[JsonIgnore]
		public virtual MedicoDTO Medico { get; set; }
		
		public String NomeMedico { get; set; }
		public String RegistroMedico { get; set; }

		public Double Peso { get; set; }
		public Double Altura { get; set; }
		public string Diagnostico { get; set; }
		public MembroDominante MembroDominante { get; set; }
		
		public bool HistoricoLesao { get; set; }
		[JsonIgnore]
		public String HistoricoLesaoDescricao { get; set; }
		public String HMA { get; set; }
		public String Comobirdades { get; set; }
		public String MedicacaoEmUso { get; set; }
		public String MedicacaoLesao { get; set; }
		public bool DormeBem { get; set; }
		public bool Fuma { get; set; }
		[JsonIgnore]
		public String ObservacaoFuma { get; set; }
		public bool Cirurgia { get; set; }
		[JsonIgnore]
		public String ObservacaoCirurgia { get; set; }
		public bool PraticaAtividadeFisica { get; set; }
		[JsonIgnore]
		public String ObservacaoAtividade { get; set; }
		public String AvaliacaoPostural { get; set; }
		public String MembrosAtivos { get; set; }
		public String MembrosPassivos { get; set; }
		public String TestesEspeciais { get; set; }
		public String TestesFuncionais { get; set; }
		public String OutrasObservacoes { get; set; }
		public String CondutaCurtoPrazo { get; set; }
		public String CondutaMedioPrazo { get; set; }
		public String CondutaLongoPrazo { get; set; }

		
	}
}
