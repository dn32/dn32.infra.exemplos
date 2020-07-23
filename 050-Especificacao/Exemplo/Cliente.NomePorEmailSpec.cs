using dn32.infra;
using System.Linq;

// Documentação: https://github.com/dn32/dn32.infra/wiki/Especificacao

public class NomeDoClientePorEmailSpec : DnEspecificacaoAlternativa<Cliente, string>
{
    public string Email { get; set; }

    public NomeDoClientePorEmailSpec AdicionarEmail(string email)
    {
        Email = email.ToLower();
        return this;
    }

    public override IQueryable<string> Where(IQueryable<Cliente> query)
    {
        return query
                    .Where(x => x.Email.ToLower() == Email)
                    .Select(x => x.Nome);
    }

    public override IOrderedQueryable<string> Order(IQueryable<string> query) => query.OrderBy(x => x);
}
