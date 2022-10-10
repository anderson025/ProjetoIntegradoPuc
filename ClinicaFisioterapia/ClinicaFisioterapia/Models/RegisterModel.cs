using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaFisioterapia.Models {
	public class RegisterModel {

		[Required]
		[EmailAddress]
		public String Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public String Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name ="Confirma a senha")]
		[Compare("Password", ErrorMessage ="Senhas não conferem")]
		public String ConfirmPassword { get; set; }
	}
}
