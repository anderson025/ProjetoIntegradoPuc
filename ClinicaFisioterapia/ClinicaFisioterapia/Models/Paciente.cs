using System.Text.Json.Serialization;

namespace ClinicaFisioterapia.Models {
	public class Paciente : Pessoa {

		[JsonIgnore]
		public virtual Avaliacao Avaliacao { get; set; }
	}
}
