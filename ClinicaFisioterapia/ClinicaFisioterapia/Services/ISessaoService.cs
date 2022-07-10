using ClinicaFisioterapia.Context.Dtos.Sessao;
using ClinicaFisioterapia.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public interface ISessaoService {

		Task<SessaoDTO> BuscaSessaoPorId(Int32 id);

		Task<Sessao> AdicionaSessao(SessaoDTO sessaoDto);

		Task ApagaSessao(Int32 id);

		Task AtualizaSessao(Sessao sessao);		

		Task<IEnumerable<SessaoDTO>> BuscaTodasSessoes();
	}
}
