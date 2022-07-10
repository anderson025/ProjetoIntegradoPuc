using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models {
	public class Avaliacao {

		[Key]
		public Int32 Id { get; set; }
		public virtual Funcionario Funcionario { get; set; }
		[Required]
		public Int32 IdFuncionario { get; set; }

		public virtual Paciente Paciente { get; set; }
		public Int32 IdPaciente { get; set; }

		public  virtual Medico Medico { get; set; }
		public Int32 IdMedico { get; set; }

		public Double Peso { get; set; }
		public Double Altura { get; set; }
		public string Diagnostico { get; set; }
		public MembroDominante MembroDominante { get; set; }
		public bool HistoricoLesao { get; set; }
		public String HistoricoLesaoDescricao { get; set; }
		public String HMA { get; set; }
		public String Comobirdades { get; set; }
		public String MedicacaoEmUso { get; set; }
		public String MedicacaoLesao { get; set; }
		public bool DormeBem { get; set; }
		public bool Fuma { get; set; }
		public String ObservacaoFuma { get; set; }
		public bool Cirurgia { get; set; }
		public String ObservacaoCirurgia { get; set; }
		public bool PraticaAtividadeFisica { get; set; }
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

		public virtual List<Sessao> Sessoes { get; set; }


	}

	public enum MembroDominante {
		direito = 0,
		esquerdo = 1
	}
}
