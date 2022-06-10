using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Models {
	public class Endereco {

		[Key]
		[Required]
		public int Id { get; set; }
		public String Rua { get; set; }
		public Int32 Numero { get; set; }
		public String Bairro { get; set; }
		[Required]
		public String Cep { get; set; }
		public String Cidade { get; set; }
		public String Estado { get; set; }
		public String Uf { get; set; }
		[JsonIgnore]
		public virtual Funcionario Funcionario { get; set; }
	}
}
