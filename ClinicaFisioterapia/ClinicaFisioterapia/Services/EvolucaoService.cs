using AutoMapper;
using ClinicaFisioterapia.Context;
using ClinicaFisioterapia.Context.Dtos.Evolucao;
using ClinicaFisioterapia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public class EvolucaoService : IEvolucaoService {

		private readonly AppDbContext _context;
		private IMapper _mapper;

		public EvolucaoService(AppDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}



		public async Task<Evolucao> AdicionaEvolucao(EvolucaoDTO evolucaoDto) {

			Evolucao evolucao = _mapper.Map<Evolucao>(evolucaoDto);
			_context.Evolucao.Add(evolucao);
			await _context.SaveChangesAsync();
			return evolucao;
		}

		public async Task ApagaEvolucao(Int32 id) {

			Evolucao evolucao = await _context.Evolucao.FindAsync(id);
			_context.Evolucao.Remove(evolucao);
			await _context.SaveChangesAsync();
		}

		public async Task AtualizaEvolucao(Evolucao evolucao) {
			_context.Entry(evolucao).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<Evolucao> BuscaEvolucaoPorId(Int32 id) {
			var evolucao = await _context.Evolucao.FindAsync(id);
			return evolucao;
		}

		public Task<IEnumerable<Evolucao>> BuscaPorData(string data) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Evolucao>> BuscaPorNomeFuncionario(string nomeFuncionario) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Evolucao>> BuscaPorNomePaciente(string nomePaciente) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Evolucao>> BuscaTodasEvolucoes() {
			throw new System.NotImplementedException();
		}
	}
}
