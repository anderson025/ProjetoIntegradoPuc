using System;

namespace ClinicaFisioterapia.Models {
	public class UserToken {

		public String Token { get; set; }
		public DateTime Expiration { get; set; }
	}
}
