namespace ClinicaFisioterapia.Models {
	public class Avaliacao {

		public int Id { get; set; }
		public Funcionario Funcionario { get; set; }
		public Paciente Paciente { get; set; }
		public Medico Medico { get; set; }
	}
}
