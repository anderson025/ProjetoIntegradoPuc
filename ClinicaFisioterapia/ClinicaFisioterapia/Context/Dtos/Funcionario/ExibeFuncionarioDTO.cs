using ClinicaFisioterapia.Context.Dtos.Endereco;
using ClinicaFisioterapia.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Context.Dtos.Funcionario {
	public class ExibeFuncionarioDTO {

		[Key]
		public Int32 Id { get; set; }
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
		
		public virtual EnderecoDTO Endereco { get; set; }
		public Int32 EnderecoId { get; set; }

		[Required]
		[EmailAddress]
		public String Email { get; set; }

		[Required]
		public String Usuario { get; set; }
	
	}
}
