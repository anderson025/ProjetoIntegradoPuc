using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models {
	public class LoginModel {


		[Required(ErrorMessage ="Email é obrigatório")]
		[EmailAddress(ErrorMessage ="Formato de email inválido")]
		public String Email { get; set; }

		[Required(ErrorMessage ="A senha é obrigatória")]
		[StringLength(20, ErrorMessage = "A {0}  deve tero mínimo {2} e no máximo {1} caracteres.", MinimumLength = 5)]
		[DataType(DataType.Password)]
		public String Password { get; set; }
	}
}
