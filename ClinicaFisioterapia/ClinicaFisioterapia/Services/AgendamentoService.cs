using AutoMapper;
using ClinicaFisioterapia.Context;
using ClinicaFisioterapia.Context.Dtos.Agendamento;
using ClinicaFisioterapia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public class AgendamentoService : IAgendamentoService {

		private readonly AppDbContext _context;
		private IMapper _mapper;

		public AgendamentoService(AppDbContext context, IMapper mapper) {

			_context = context;
			_mapper = mapper;
		}

		public async Task<Agendamento> AdicionaAgendamento(AgendamentoDTO agendamentoDto) {

			bool agendaMarcada = VerificaDisponibilidadeDaAgenda(agendamentoDto.DataAgendamento.ToString());

			if (!agendaMarcada) {
				Agendamento agendamento = _mapper.Map<Agendamento>(agendamentoDto);
				_context.Agendamento.Add(agendamento);
				await _context.SaveChangesAsync();
				return agendamento;
			}

			return null;
		}

		public bool VerificaDisponibilidadeDaAgenda(String date) {

			IEnumerable<Agendamento> agendamentos;

			if (!string.IsNullOrWhiteSpace(date)) {

				agendamentos = _context.Agendamento.Where(n => n.DataAgendamento.Date == DateTime.Parse(date).Date).ToList();

				if (agendamentos.Count() > 0) {
					return true;
				}				

			}	

			return false;
		}

		public async Task<IEnumerable<ExibeAgendamentoDTO>> BuscaTodosAgendamentos() {

			try {
				var agendamento = await _context.Agendamento.ToListAsync();
				return _mapper.Map<IEnumerable<ExibeAgendamentoDTO>>(agendamento);
			}
			catch {

				throw;
			}

		}

		public async Task ApagaAgendamento(Int32 id) {

			Agendamento agendamento = await _context.Agendamento.FindAsync(id);
			_context.Agendamento.Remove(agendamento);
			await _context.SaveChangesAsync();
		}

		public async Task AtualizaAgendamento(Agendamento agendamento) {

			_context.Entry(agendamento).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<ExibeAgendamentoDTO> BuscaAgendamentoPorId(int id) {

			var agendamento = await _context.Agendamento.FindAsync(id);			
			return _mapper.Map<ExibeAgendamentoDTO>(agendamento); ;
		}

		public async Task<IEnumerable<Agendamento>> BuscaPorData(String date) {

			IEnumerable<Agendamento> agendamentos;

			if (!string.IsNullOrWhiteSpace(date)) {

				agendamentos = await _context.Agendamento.Where(n => n.DataAgendamento.Date == DateTime.Parse(date).Date).ToListAsync();

				if (agendamentos.Count() > 0) {
					return agendamentos;
				}

			}

			return null;
		}

		public async Task<IEnumerable<Agendamento>> BuscaPorNomeFuncionario(String nomePaciente) {

			IEnumerable<Agendamento> agendamentos;
			IEnumerable<ExibeAgendamentoDTO> agendamentoDTOs;
			if (!string.IsNullOrWhiteSpace(nomePaciente)) {

				agendamentos = await _context.Agendamento.Where(n => n.Funcionario.Nome.Contains(nomePaciente)).ToListAsync();
				return agendamentos;

			}
			else {
				agendamentoDTOs = await BuscaTodosAgendamentos();
				return _mapper.Map<IEnumerable<Agendamento>>(agendamentoDTOs);
			}
			
		}

		public async Task<IEnumerable<Agendamento>> BuscaPorNomePaciente(string nomePaciente) {

			IEnumerable<Agendamento> agendamentos;
			//IEnumerable<ExibeFuncionarioDTO> funcionarioDTOs;
			if (!string.IsNullOrWhiteSpace(nomePaciente)) {

				agendamentos = await _context.Agendamento.Where(n => n.Paciente.Nome.Contains(nomePaciente)).ToListAsync();
				return agendamentos;

			}
			else {
				agendamentos = null;
				return agendamentos;
			}
		}
	}
}
