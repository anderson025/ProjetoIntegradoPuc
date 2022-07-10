using AutoMapper;
using ClinicaFisioterapia.Context;
using ClinicaFisioterapia.Context.Dtos.Medico;
using ClinicaFisioterapia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public class MedicoService : IMedicoService {

		private readonly AppDbContext _context;
		private IMapper _mapper;

		public MedicoService(AppDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		public async Task<Medico> AdicionaMedico(MedicoDTO medicoDto) {

			Medico medico = _mapper.Map<Medico>(medicoDto);
			_context.Medico.Add(medico);
			await _context.SaveChangesAsync();
			return medico;
		}

		public async Task ApagaMedico(Int32 id) {
			Medico medico = await _context.Medico.FindAsync(id);
			_context.Medico.Remove(medico);
			await _context.SaveChangesAsync();
		}

		public async Task AtualizaMedico(Medico medico) {
			_context.Entry(medico).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<Medico> BuscaMedicoPorId(Int32 id) {

			var medico = await _context.Medico.FindAsync(id);
			//ExibiFuncionarioDTO funcionarioDTO = _mapper.Map<ExibiFuncionarioDTO>(funcionario);
			return medico;
		}

		public async Task<IEnumerable<Medico>> BuscaTodosMedicos() {
			try {
				IEnumerable<Medico> medico = await _context.Medico.ToListAsync();
				return medico;
			}
			catch {

				throw;
			}
		}
	}
}
