using dn32.infra;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

//[DnDoc(EnumApresentar.Ocultar)] // Oculta o controller inteiro da documentação
[Route("/api/[controller]/[action]")]
public class ClienteController : DnController<Cliente>
{
    [HttpPost]
    public async Task<Cliente> Adicionar([FromBody] Cliente cliente)
    {
        return await Servico.AdicionarAsync(cliente);
    }

    [HttpGet]
    public async Task<List<Cliente>> Listar()
    {
        var spec = CriarEspecificacao<DnTudoEspecificacao<Cliente>>();
        return await Servico.ListarAsync(spec);
    }
}

public class Cliente : DnEntidade
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public string Nome { get; set; }
}
