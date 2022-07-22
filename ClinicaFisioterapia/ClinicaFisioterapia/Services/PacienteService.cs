using AutoMapper;
using ClinicaFisioterapia.Context;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public class PacienteService : IPacienteService {

		private readonly AppDbContext _context;
		private IMapper _mapper;

		public PacienteService(AppDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		public async Task AdicionaPaciente(Paciente paciente) {
			
			_context.Pacientes.Add(paciente);
			await _context.SaveChangesAsync();
		}

		public async Task ApagaPaciente(Paciente paciente) {
			_context.Pacientes.Remove(paciente);
			await _context.SaveChangesAsync();
		}

		public async Task AtualizaPaciente(Paciente paciente) {
			_context.Entry(paciente).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<Paciente> BuscaPacientePorId(Int32 id) {
			var paciente = await _context.Pacientes.FindAsync(id);
			return paciente;
		}

		public async Task<IEnumerable<Paciente>> BuscaPacientes() {
			try {
				return await _context.Pacientes.ToListAsync();
			}
			catch {

				throw;
			}
		}

		public async Task<IEnumerable<Paciente>> BuscaPorNome(String nome) {
			IEnumerable<Paciente> paciente;

			if (!string.IsNullOrWhiteSpace(nome)) {
				paciente = await _context.Pacientes.Where(n => n.Nome.Contains(nome)).ToListAsync();
			}
			else {
				paciente = await BuscaPacientes();
			}

			return paciente;
		}
	}
}
