using dn32.infra;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// Documentação: https://github.com/dn32/dn32.infra/wiki/DnPaginacao

[Route("/api/[controller]/[action]")]
public class ClienteController : DnController<Cliente>
{
    [HttpPost]
    public async Task<Cliente> Adicionar([FromBody] Cliente cliente)
    {
        return await Servico.AdicionarAsync(cliente);
    }

    //http://localhost:5000/api/cliente/Listar?paginaAtual=1
    [HttpGet]
    public async Task<List<Cliente>> Listar(int paginaAtual)
    {
        var paginacao = DnPaginacao.Criar(paginaAtual);
        var spec = CriarEspecificacao<DnTudoEspecificacao<Cliente>>();
        return await Servico.ListarAsync(spec, paginacao);
    }

    //http://localhost:5000/api/cliente/ListarPaginacaoPorParametro?paginaAtual=2&itensPorPagina=5&iniciaComZero=true
    [HttpGet]
    [HttpPost]
    public async Task<List<Cliente>> ListarPaginacaoPorParametro()
    {
        var spec = CriarEspecificacao<DnTudoEspecificacao<Cliente>>();
        return await Servico.ListarAsync(spec);
    }
}