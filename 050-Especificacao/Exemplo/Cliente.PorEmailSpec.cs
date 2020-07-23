using dn32.infra;
using System.Linq;

// Documentação: https://github.com/dn32/dn32.infra/wiki/Especificacao

public class ClientePorEmailSpec : DnEspecificacao<Cliente>
{
    public string Email { get; set; }

    public ClientePorEmailSpec AdicionarEmail(string email)
    {
        Email = email.ToLower();
        return this;
    }

    public override IQueryable<Cliente> Where(IQueryable<Cliente> query) =>
        query.Where(x => x.Email.ToLower() == Email);

    public override IOrderedQueryable<Cliente> Order(IQueryable<Cliente> query) =>
        query.OrderBy(x => x.Nome);
}
