using dn32.infra;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

[Route("/api/[Controller]/[Action]")]
public class UsuarioController : DnApiController<Usuario>
{
    [HttpGet]
    public IActionResult MinhaActionCustomizada()
    {
        return Content("Ola!");
    }

    [NonAction] // Não cria action
    public override Task<DnResultadoPadrao<bool>> EliminarTudo([FromHeader] string APAGAR_TUDO = "false")
    {
        return base.EliminarTudo(APAGAR_TUDO);
    }
   
    [DnDoc(apresentar: EnumApresentar.Ocultar)] // Não apresenta a action na documentação
    [HttpGet]
    public IActionResult ActionOculta()
    {
        return Content("Ola!");
    }
}

/* 3. Exemplo de entidade */
public class Usuario : DnEntidade
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }
}
