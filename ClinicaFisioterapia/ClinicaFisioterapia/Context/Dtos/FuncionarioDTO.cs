using ClinicaFisioterapia.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Context.Dtos {
	public class FuncionarioDTO {

		[Required]
		public string Nome { get; set; }
		[Required]
		public DateTime DataNascimento { get; set; }
		public Int32 Idade { get; set; }
		[Required]
		public String Rg { get; set; }
		[Required]
		public String Cpf { get; set; }
		public Sexo Sexo { get; set; }
		public bool Situacao { get; set; }
		public String Telefone { get; set; }
		[Required]
		public String Celular { get; set; }
		[Required]
		public Profissao Profissao { get; set; }
		public String Convenio { get; set; }
		public Int32 CarteiraConvenio { get; set; }
		[Required]
		public virtual EnderecoDTO Endereco { get; set; }
		public Int32 EnderecoId { get; set; }

		[Required]
		[EmailAddress]
		public String Email { get; set; }

		[Required]
		public String Usuario { get; set; }
		[Required]
		public String Senha { get; set; }
	}
}
