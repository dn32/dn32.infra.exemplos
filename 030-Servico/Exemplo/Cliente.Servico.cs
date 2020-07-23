using System.Threading.Tasks;
using dn32.infra;

public class ClienteServico : DnServico<Cliente>
{
    public override async Task<Cliente> AdicionarAsync(Cliente entidade)
    {
        await Validacao.AdicionarAsync(entidade);
        return await Repositorio.AdicionarAsync(entidade);
    }

    public async Task AdicionarCustomizado(string email, string name)
    {
        var entidade = new Cliente
        {
            Email = email,
            Nome = name
        };

        await Validacao.AdicionarAsync(entidade);
        await Repositorio.AdicionarAsync(entidade);
    }

    public int ObterQuantidade() => 10;
}