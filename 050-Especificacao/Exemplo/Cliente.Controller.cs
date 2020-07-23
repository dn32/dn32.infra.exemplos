using dn32.infra;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// Documentação: https://github.com/dn32/dn32.infra/wiki/Especificacao

[Route("/api/[controller]/[action]")]
public class ClienteController : DnController<Cliente>
{
    [HttpPost]
    public async Task<Cliente> Adicionar([FromBody] Cliente cliente)
    {
        return await Servico.AdicionarAsync(cliente);
    }

    [HttpGet]
    public async Task<Cliente> BuscarPorEmail(string email)
    {
        var spec = CriarEspecificacao<ClientePorEmailSpec>().AdicionarEmail(email);
        return await Servico.PrimeiroOuPadraoAsync(spec);
    }

    [HttpGet]
    public async Task<string> NomeDoClientePorEmail(string email)
    {
        var spec = CriarEspecificacao<NomeDoClientePorEmailSpec>().AdicionarEmail(email);
        return await Servico.PrimeiroOuPadraoAlternativoAsync(spec);
    }

    [HttpGet]
    public async Task<List<ClienteComEnderecoViewModel>> ListarClientesComEnderecos()
    {
        var spec = CriarEspecificacao<ClienteComEnderecoSpec>();
        return await Servico.ListarAlternativoAsync(spec);
    }
}