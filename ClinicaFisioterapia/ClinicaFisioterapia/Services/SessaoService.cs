using AutoMapper;
using ClinicaFisioterapia.Context;
using ClinicaFisioterapia.Context.Dtos.Sessao;
using ClinicaFisioterapia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public class SessaoService : ISessaoService {

		private readonly AppDbContext _context;
		private IMapper _mapper;

		public SessaoService(AppDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		public async Task<Sessao> AdicionaSessao(SessaoDTO sessaoDto) {

			var sessao = _mapper.Map<Sessao>(sessaoDto);
			_context.Sessao.Add(sessao);
			await _context.SaveChangesAsync();
			return sessao;
		}

		public async Task ApagaSessao(int id) {

			Sessao sessao = await _context.Sessao.FindAsync(id);
			_context.Sessao.Remove(sessao);
			await _context.SaveChangesAsync();
		}

		public async Task AtualizaSessao(Sessao sessao) {
			_context.Entry(sessao).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<SessaoDTO> BuscaSessaoPorId(Int32 id) {
			var sessao = await _context.Sessao.FindAsync(id);
			return _mapper.Map<SessaoDTO>(sessao);
		}

		public async Task<IEnumerable<SessaoDTO>> BuscaTodasSessoes() {

			try {
				var sessao = await _context.Sessao.ToListAsync();
				return _mapper.Map<IEnumerable<SessaoDTO>>(sessao);
			}
			catch {

				throw;
			}
		}
	}
}
