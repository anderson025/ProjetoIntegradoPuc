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

		public Task ApagaAgendamento(int id) {
			throw new System.NotImplementedException();
		}

		public Task AtualizaAgendamento(Agendamento agendamento) {
			throw new System.NotImplementedException();
		}

		public async Task<ExibeAgendamentoDTO> BuscaAgendamentoPorId(int id) {

			var agendamento = await _context.Agendamento.FindAsync(id);			
			return _mapper.Map<ExibeAgendamentoDTO>(agendamento); ;
		}

		public Task<string> BuscaPorData(string data) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Funcionario>> BuscaPorNomeFuncionario(string nomePaciente) {
			throw new System.NotImplementedException();
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
