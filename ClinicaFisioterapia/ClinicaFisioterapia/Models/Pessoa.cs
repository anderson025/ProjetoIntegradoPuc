using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Models {
	public class Pessoa {

		[Key]
		public Int32 Id { get; set; }
		[Required]
		public String Nome { get; set; }
		
		public DateTime DataNascimento { get; set; }
		public Int32 Idade { get; set; }
		[Required]
		public String Rg { get; set; }
		[Required]
		public String Cpf { get; set; }
		public Sexo Sexo { get; set; }
		public bool Situacao { get; set; }
		public String Telefone { get; set; }
		
		public String Celular { get; set; }
		
		public Profissao Profissao { get; set; }
		public String Convenio { get; set; }
		public Int32 CarteiraConvenio { get; set; }
		
		public virtual Endereco Endereco { get; set; }
		public Int32 EnderecoId { get; set; }

		[Required]
		[EmailAddress]
		public String Email { get; set; }

		[JsonIgnore]
		public virtual Agendamento Agendamento { get; set; }
		

		

	}

	public enum Sexo {
		masculino = 0,
		feminino = 1
	}

	public enum Profissao {
		fisioterapeuta = 0,
		recepcionista = 1,
		medico = 2
	}
}

