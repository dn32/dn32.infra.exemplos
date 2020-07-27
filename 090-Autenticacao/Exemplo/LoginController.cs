using dn32.infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

[Route("/api/Login/[Action]")]
public class LoginController : DnControllerDeServico<ServicoDeAutenticacao>
{
    //http://localhost:5000/api/Login/Entrar
    [AllowAnonymous]
    [HttpPost]
    public async Task<string> Entrar([FromBody] DnUsuarioParaAutenticacao usuario)
    {
        return await Servico.EntrarAsync(usuario);
    }
    //http://localhost:5000/api/Login/ObterIdDoClienteLogado?Authorization=[token]
    // Note que o acesso a este método é feito somente por usuários autenticados e autenticação se da por meio do token passado pelo Header ou QueryString
    [HttpGet]
    public string ObterIdDoClienteLogado()
    {
        return HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("email-do-cliente")).Value;
    }

    [AllowAnonymous]
    [HttpPost]
    //http://localhost:5000/api/Login/Registrar {POST}
    public async Task<Usuario> Registrar([FromBody] Usuario usuario)
    {
        usuario.SenhaCifrada = usuario.Senha.MD5Hash();
        return await Servico.Registrar(usuario);
    }
}
