using AutoMapper;
using ClinicaFisioterapia.Context;
using ClinicaFisioterapia.Context.Dtos.Agendamento;
using ClinicaFisioterapia.Context.Dtos.Avaliacao;
using ClinicaFisioterapia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public class AvaliacaoService : IAvaliacaoService {

		private readonly AppDbContext _context;
		private IMapper _mapper;

		public AvaliacaoService(AppDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		public async Task<ExibeAvaliacaoDTO> AdicionaAvaliacao(AvaliacaoDTO avaliacaoDto) {


			Avaliacao avaliacao = _mapper.Map<Avaliacao>(avaliacaoDto);
			_context.Avaliacao.Add(avaliacao);
			await _context.SaveChangesAsync();
			return _mapper.Map<ExibeAvaliacaoDTO>(avaliacao);

		}

		public async Task ApagaAvaliacao(Int32 id) {

			Avaliacao avaliacao = await _context.Avaliacao.FindAsync(id);
			_context.Avaliacao.Remove(avaliacao);
			await _context.SaveChangesAsync();
		}

		public async Task AtualizaAvaliacao(Avaliacao avaliacao) {

			_context.Entry(avaliacao).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<ExibeAvaliacaoDTO> BuscaAvaliacaoPorId(Int32 id) {
			var avaliacao = await _context.Avaliacao.FindAsync(id);
			return _mapper.Map<ExibeAvaliacaoDTO>(avaliacao);
		}

		public Task<IEnumerable<Avaliacao>> BuscaPorData(string data) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Avaliacao>> BuscaPorNomeFuncionario(string nomePaciente) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Avaliacao>> BuscaPorNomePaciente(string nomePaciente) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<ExibeAgendamentoDTO>> BuscaTodasAvaliacoes() {
			throw new System.NotImplementedException();
		}
	}
}
