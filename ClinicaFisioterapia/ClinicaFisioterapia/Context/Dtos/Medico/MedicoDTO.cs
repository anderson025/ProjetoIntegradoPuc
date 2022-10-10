using ClinicaFisioterapia.Context.Dtos.Avaliacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Context.Dtos.Medico {
	public class MedicoDTO {

		[Required]
		public String NameMedico { get; set; }
		[Required]
		public String CRM { get; set; }

		//[JsonIgnore]
		//public virtual List<AvaliacaoDTO> Avaliacoes { get; set; }
	}
}
