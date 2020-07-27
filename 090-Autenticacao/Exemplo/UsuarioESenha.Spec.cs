using System.Linq;
using dn32.infra;

public class UsuarioESenhaEspecificacao : DnEspecificacao<Usuario>
{
    public string Email { get; set; }
    public string SenhaMD5 { get; set; }

    public UsuarioESenhaEspecificacao AdicionarParametros(string email, string senha)
    {
        Email = email?.ToLower();
        SenhaMD5 = senha.MD5Hash();

        return this;
    }

    public override IQueryable<Usuario> Where(IQueryable<Usuario> query)
    {
        return query.Where(x => x.Email.ToLower() == Email && x.SenhaCifrada == SenhaMD5);
    }

    public override IOrderedQueryable<Usuario> Order(IQueryable<Usuario> query)
    {
        return query.OrderBy(x => x.Nome);
    }
}
