using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Context.Dtos.Endereco {
	public class EnderecoDTO {

		public String Rua { get; set; }
		public Int32 Numero { get; set; }
		public String Bairro { get; set; }
		[Required]
		public String Cep { get; set; }
		public String Cidade { get; set; }
		public String Estado { get; set; }
		public String Uf { get; set; }
		[JsonIgnore]
		public virtual FuncionarioDTO FuncionarioDTO { get; set; }
		[JsonIgnore]
		public virtual PacienteDTO PacienteDTO { get; set; }
	}
}
