﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models {
	public class Funcionario {

		[Key]
		public Int32 Id { get; set; }
		[Required]
		public String Nome { get; set; }
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
		public virtual Endereco Endereco { get; set; }
		public Int32 EnderecoId { get; set; }
		[Required]
		public String Usuario { get; set; }
		[Required]
		public String Senha { get; set; }

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