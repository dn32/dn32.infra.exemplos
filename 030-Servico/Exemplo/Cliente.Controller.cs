using dn32.infra;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("/api/[controller]/[action]")]
public class ClienteController : DnController<Cliente>
{
    public new ClienteServico Servico => base.Servico as ClienteServico;

    [HttpPost]
    public async Task<Cliente> Adicionar([FromBody] Cliente cliente)
    {
        return await Servico.AdicionarAsync(cliente);
    }

    [HttpPost]
    public async Task AdicionarCustomizado([FromBody] Cliente cliente)
    {
        await Servico.AdicionarCustomizado(cliente.Email, cliente.Nome);
    }

    [HttpGet]
    public async Task<List<Cliente>> Listar()
    {
        var spec = CriarEspecificacao<DnTudoEspecificacao<Cliente>>();
        return await Servico.ListarAsync(spec);
    }

    [HttpGet]
    public async Task<bool> VerificarSeClienteExistePeloId(int clienteId)
    {
        return await Servico.ExisteAsync(new Cliente { Id = clienteId });
    }
}