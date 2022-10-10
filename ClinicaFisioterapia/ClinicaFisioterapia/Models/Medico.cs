using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Models {
	public class Medico {

		[Key]
		public Int32 Id { get; set; }
		[Required]
		public String NameMedico { get; set; }
		[Required]
		public String CRM { get; set; }

		//[JsonIgnore]
		//public virtual List<Avaliacao> Avaliacoes { get; set; }
	}
}