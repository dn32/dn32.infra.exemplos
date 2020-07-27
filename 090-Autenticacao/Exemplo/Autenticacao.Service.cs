using dn32.infra;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

public class ServicoDeAutenticacao : DnServicoDeAutenticacao
{
    protected virtual DnServico<Usuario> ServicoDeUsuario => null;

    public override async Task<(bool sucess, List<Claim> claims)> AutenticarAsync(DnUsuarioParaAutenticacao usuario)
    {
        var spec = CriarEspecificacao<UsuarioESenhaEspecificacao>().AdicionarParametros(usuario.Email, usuario.Senha);
        var sucess = await ServicoDeUsuario.ExisteAsync(spec);
        var claims = new List<Claim>() { new Claim("email-do-cliente", usuario.Email) };

        return await Task.FromResult((sucess, claims));
    }

    public async Task<Usuario> Registrar(Usuario usuario)
    {
        return await ServicoDeUsuario.AdicionarAsync(usuario);
    }
}
