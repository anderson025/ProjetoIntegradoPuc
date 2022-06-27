using AutoMapper;
using ClinicaFisioterapia.Context;
using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public class FuncionariosService : IFuncionarioService {

		private readonly AppDbContext _context;
		private IMapper _mapper;

		public FuncionariosService(AppDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}
				

		public async Task<ExibiFuncionarioDTO> AdicionaFuncionario(FuncionarioDTO funcionarioDto) {

			Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);
			_context.Funcionario.Add(funcionario);
			await _context.SaveChangesAsync();
			return _mapper.Map<ExibiFuncionarioDTO>(funcionario);
			
		}

		public async Task ApagaFuncionario(Funcionario funcionario) {
			//Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);
			_context.Funcionario.Remove(funcionario);
			await _context.SaveChangesAsync();
			
		}

		public async Task AtualizaFuncionario(Funcionario funcionario) {
			_context.Entry(funcionario).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<ExibiFuncionarioDTO>> BuscaFuncionario() {
			
			try {
				IEnumerable<Funcionario> funcionario = await _context.Funcionario.ToListAsync();
				return _mapper.Map<IEnumerable<ExibiFuncionarioDTO>>(funcionario);
			}
			catch  {

				throw;
			}
			
		}

		public async Task<Funcionario> BuscaFuncionarioPorId(Int32 id) {
			
			var funcionario = await _context.Funcionario.FindAsync(id);
			//ExibiFuncionarioDTO funcionarioDTO = _mapper.Map<ExibiFuncionarioDTO>(funcionario);
			return funcionario;
		}

		public async Task<IEnumerable<ExibiFuncionarioDTO>> BuscaPorNome(string nome) {

			IEnumerable<Funcionario> funcionarios;
			IEnumerable<ExibiFuncionarioDTO> funcionarioDTOs;
			if (!string.IsNullOrWhiteSpace(nome)) {

				funcionarios = await _context.Funcionario.Where(n => n.Nome.Contains(nome)).ToListAsync();
				return _mapper.Map<IEnumerable<ExibiFuncionarioDTO>>(funcionarios);
				
			}
			else {
				funcionarioDTOs = await BuscaFuncionario();
				return funcionarioDTOs;
			}

			
		}

		
	}
}
