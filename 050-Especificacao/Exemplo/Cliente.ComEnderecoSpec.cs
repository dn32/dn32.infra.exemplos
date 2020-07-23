using dn32.infra;
using System.Linq;

// Documentação: https://github.com/dn32/dn32.infra/wiki/Especificacao

public class ClienteComEnderecoSpec : DnEspecificacaoAlternativa<Cliente, ClienteComEnderecoViewModel>
{
    public override IQueryable<ClienteComEnderecoViewModel> Where(IQueryable<Cliente> query)
    {
       var enderecos = ObterEntidade<Endereco>();

        return query
            .Join(enderecos, cliente => cliente.Id, endereco => endereco.ClienteId, (cliente, endereco) =>
                new ClienteComEnderecoViewModel
                {
                    Nome = cliente.Nome,
                    Endereco = endereco.Rua + " " + endereco.Numero
                });
    }

    public override IOrderedQueryable<ClienteComEnderecoViewModel> Order(IQueryable<ClienteComEnderecoViewModel> query) => query.OrderBy(x => x.Nome);
}